using AutoMapper;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using RequestManager.API.DTOs;
using RequestManager.API.Handlers.AddNewRequest;
using RequestManager.API.Handlers.DeleteRequestHandler;
using RequestManager.API.Handlers.GetAllCouriers;
using RequestManager.API.Handlers.GetRequest;
using RequestManager.API.Handlers.UpdateRequestHandler;
using RequestManager.Shared;
using System.Text;
using System.Text.RegularExpressions;

namespace RequestManager.Client.Pages;

public partial class RequestRegistry
{
    [Inject] private GetRequestsHandler GetRequestHandler { get; set; }

    [Inject] private GetCouriersHandler GetCourierHandler { get; set; }

    [Inject] private AddRequestHandler AddRequestHandler { get; set; }

    [Inject] private DeleteRequestHandler DeleteRequestHandler { get; set; }

    [Inject] private UpdateRequestHandler UpdateRequestHandler { get; set; }

    [Inject] private IMapper Mapper { get; set; }

    private List<RequestDTO> Requests { get; set; }

    private List<CourierDTO> Couriers { get; set; }

    private HashSet<RequestDTO> _selectedRequests = new();

    private RequestDTO BackupRequestItem { get; set; } = new();

    private MudForm _form;
    private string _searchString = "";
    private bool _visible = false;
    private bool _success;
    private string[] _errors = Array.Empty<string>();

    private RequestDTO TempRequest { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Requests = (await GetRequestHandler.Handle()).Requests.ToList();
        Couriers = (await GetCourierHandler.Handle()).Couriers.ToList();
    }

    private static bool FilterItem<T>(T item, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        var stringBuilder = new StringBuilder();
        foreach (var property in item.GetType().GetProperties())
            stringBuilder.Append(property.GetValue(item, null));

        return stringBuilder.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase);
    }

    //private async Task<TableData<RequestDTO>> ServerReload(TableState state)
    //{
    //    IEnumerable<RequestDTO> data = (await GetRequestHandler.Handle()).Requests.ToList();
    //    await Task.Delay(300);
    //    var totalItems = data.Count();

    //    var pagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
    //    return new TableData<RequestDTO>() { TotalItems = totalItems, Items = pagedData };
    //}

    private readonly DialogOptions _dialogOptions = new() { FullWidth = true, CloseButton = true };

    private void OpenAddRequestDialog()
    {
        TempRequest = new() { Status = RequestStatus.New };
        _visible = true;
    }

    private async void AddRequest()
    {
        if (TempRequest.RegistrationDate != null && TempRequest.SendersName != null && TempRequest.SendersPassport != null &&
            TempRequest.SendersPhoneNumber != null && TempRequest.RecipientsName != null && TempRequest.RecipientsPassport != null &&
            TempRequest.RecipientsPhoneNumber != null && TempRequest.CargoDescription != null && TempRequest.DeliveryAddress != null)
        {
            var utcDateTime = DateTime.SpecifyKind(TempRequest.RegistrationDate.Value, DateTimeKind.Utc);
            TempRequest.RegistrationDate = utcDateTime;
            var request = new AddRequestRequest(TempRequest);
            var requestDTO = (await AddRequestHandler.Handle(request)).RequestDTO;
            Requests.Add(requestDTO);
            StateHasChanged();
            await _form.ResetAsync();
        }
    }

    private async void DeleteRequest()
    {
        var requests = _selectedRequests.Where(x => x.Status == RequestStatus.New).ToList();
        var selectedRequests = new DeleteRequestRequest(requests);
        Requests = (await DeleteRequestHandler.Handle(selectedRequests)).RequestsDTOs.ToList();
        StateHasChanged();
    }

    private void BackupRequest(RequestDTO requestDTO)
    {
        Mapper.Map(requestDTO, BackupRequestItem);
    }

    private async void UpdateRequest(RequestDTO requestDTO)
    {
        var request = new UpdateRequestRequest(requestDTO);
        Requests = (await UpdateRequestHandler.Handle(request)).RequestDTOs.ToList();
        StateHasChanged();
    }

    private void RestoreRequest(RequestDTO requestDTO)
    {
        Mapper.Map(BackupRequestItem, requestDTO);
    }

    private static IEnumerable<string> CheckPassportValue(string passport)
    {
        if (string.IsNullOrWhiteSpace(passport))
        {
            yield return "Passport is required!";
            yield break;
        }
        else if (!Regex.IsMatch(passport, @"[0-9]"))
        {
            yield return "Passport must contain only numbers";
        }
        else if (passport.Length != 10)
        {
            yield return "Passport must be of length 10";
        }
    }
}
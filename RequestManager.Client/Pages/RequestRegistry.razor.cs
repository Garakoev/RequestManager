using Microsoft.AspNetCore.Components;
using MudBlazor;
using RequestManager.API.DTOs;
using RequestManager.API.Handlers.AddNewRequest;
using RequestManager.API.Handlers.GetAllCouriers;
using RequestManager.API.Handlers.GetRequest;
using System.Text;

namespace RequestManager.Client.Pages;

public partial class RequestRegistry
{
    [Inject] public GetRequestsHandler GetRequestHandler { get; set; }

    [Inject] public GetCouriersHandler GetCourierHandler { get; set; }

    [Inject] public AddRequestHandler AddRequestHandler { get; set; }

    private List<RequestDTO> Requests { get; set; }

    private List<CourierDTO> Couriers { get; set; }

    private HashSet<RequestDTO> _selectedRequests = new();

    private MudForm _form;
    private string _searchString = "";
    private bool _visible = false;

    private RequestDTO TempRequest { get; set; } = new();

    public RequestRegistry()
    {
    }

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

    private async Task<TableData<RequestDTO>> ServerReload(TableState state)
    {
        IEnumerable<RequestDTO> data = (await GetRequestHandler.Handle()).Requests.ToList();
        await Task.Delay(300);
        var totalItems = data.Count();

        var pagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
        return new TableData<RequestDTO>() { TotalItems = totalItems, Items = pagedData };
    }

    private readonly DialogOptions _dialogOptions = new() { FullWidth = true, CloseButton = true };

    private void OpenAddRequestDialog()
    {
        TempRequest = new() { Status = "Новая" }; //TODO Status должен быть ENUM
        _visible = true;
    }

    private async void AddRequest()
    {
        var request = new AddRequestRequest(TempRequest);

        var requestDTO = (await AddRequestHandler.Handle(request)).Request;
        Requests.Add(requestDTO);
    }
}
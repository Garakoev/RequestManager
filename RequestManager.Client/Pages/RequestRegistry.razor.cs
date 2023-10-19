using Microsoft.AspNetCore.Components;
using RequestManager.API.DTOs;
using RequestManager.API.Handlers.GetAllCouriers;
using RequestManager.API.Handlers.GetRequest;
using System.Text;

namespace RequestManager.Client.Pages;

public partial class RequestRegistry
{
    [Inject] public GetRequestsHandler GetRequestHandler { get; set; }
    [Inject] public GetCouriersHandler GetCourierHandler { get; set; }

    private List<RequestDTO> Requests { get; set; }
    private List<CourierDTO> Couriers { get; set; }

    private string _searchString = "";

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
}
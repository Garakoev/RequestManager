using RequestManager.API.Common;
using RequestManager.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace RequestManager.API.DTOs;

public class RequestDTO : IMapFrom<Request>
{
    public int Id { get; init; }

    public int Number { get; set; }

    public DateTime RegistrationDate { get; set; }

    public string SendersSurname { get; set; }

    public string SendersName { get; set; }

    public string? SendersPatronymic { get; set; }

    public int PassportSeries { get; set; }

    public int PassportNumber { get; set; }

    public string SendersPhoneNumber { get; set; }

    public string CargoName { get; set; }

    public string DeliveryAddress { get; set; }

    public string Status { get; set; }

    public string Comment { get; set; }

    public CourierDTO Courier { get; set; }
}
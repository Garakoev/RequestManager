﻿using RequestManager.API.Common;
using RequestManager.Database.Models;
using RequestManager.Shared;
using System.ComponentModel.DataAnnotations;

namespace RequestManager.API.DTOs;

public class RequestDTO : IMapFrom<Request>
{
    public long Id { get; init; }

    public DateTime? RegistrationDate { get; set; }

    public string SendersName { get; set; }

    public string SendersPassport { get; set; }

    public string SendersPhoneNumber { get; set; }

    public string RecipientsName { get; set; }

    public string RecipientsPassport { get; set; }

    public string RecipientsPhoneNumber { get; set; }

    public string CargoDescription { get; set; }

    public string DeliveryAddress { get; set; }

    public RequestStatus Status { get; set; }

    public string Comment { get; set; }

    public CourierDTO Courier { get; set; }
}
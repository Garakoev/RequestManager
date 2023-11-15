using RequestManager.Database.Models.Common;
using RequestManager.Shared;
using System.ComponentModel.DataAnnotations;

namespace RequestManager.Database.Models;

public class Request : DatabaseEntity
{
    [Required]
    public DateTime? RegistrationDate { get; set; }

    [Required]
    public string SendersName { get; set; }

    [Required, StringLength(10)]
    public string SendersPassport { get; set; }

    [Required, StringLength(12)]
    public string SendersPhoneNumber { get; set; }

    [Required]
    public string RecipientsName { get; set; }

    [Required, StringLength(10)]
    public string RecipientsPassport { get; set; }

    [Required, StringLength(12)]
    public string RecipientsPhoneNumber { get; set; }

    [Required]
    public string CargoDescription { get; set; }

    [Required]
    public string DeliveryAddress { get; set; }

    [Required]
    public RequestStatus Status { get; set; }

    public string Comment { get; set; }

    public Courier Courier { get; set; }
}
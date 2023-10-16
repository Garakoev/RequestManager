using RequestManager.Database.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace RequestManager.Database.Models;

public class Request : DatabaseEntity
{
    [Required]
    public int Number { get; set; }

    [Required]
    public DateTime RegistrationDate { get; set; }

    [Required]
    public string SendersSurname { get; set; }

    [Required]
    public string SendersName { get; set; }

    public string? SendersPatronymic { get; set; }

    [Required, MaxLength(4)]
    public int PassportSeries { get; set; }

    [Required, MaxLength(6)]
    public int PassportNumber { get; set; }

    [Required, StringLength(12)]
    public string SendersPhoneNumber { get; set; }

    [Required]
    public string CargoName { get; set; }

    [Required]
    public string DeliveryAddress { get; set; }

    [Required]
    public string Status { get; set; }

    public string Comment { get; set; }

    public Courier Courier { get; set; }
}
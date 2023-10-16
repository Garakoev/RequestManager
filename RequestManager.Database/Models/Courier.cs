using RequestManager.Database.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace RequestManager.Database.Models;

public class Courier : DatabaseEntity
{
    [Required]
    public string Surname { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Patronymic { get; set; }

    [Required, StringLength(12)]
    public string PhoneNumber { get; set; }

    public List<Request> Requests { get; set; }
}
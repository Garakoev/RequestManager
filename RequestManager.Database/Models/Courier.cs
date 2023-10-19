using RequestManager.Database.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace RequestManager.Database.Models;

public class Courier : DatabaseEntity
{
    [Required]
    public string Name { get; set; }

    [Required, StringLength(12)]
    public string PhoneNumber { get; set; }

    [Required, StringLength(10)]
    public string Passport { get; set; }

    public List<Request> Requests { get; set; }
}
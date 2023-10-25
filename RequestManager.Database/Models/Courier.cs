using RequestManager.Database.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace RequestManager.Database.Models;

public class Courier : DatabaseEntity
{
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Passport { get; set; }

    public ICollection<Request> Requests { get; set; }
}
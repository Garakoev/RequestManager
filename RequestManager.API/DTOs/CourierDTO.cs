using RequestManager.API.Common;
using RequestManager.Database.Models;

namespace RequestManager.API.DTOs;

public class CourierDTO : IMapFrom<Courier>
{
    public int Id { get; init; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Passport { get; set; }

    public List<RequestDTO> Requests { get; set; }
}
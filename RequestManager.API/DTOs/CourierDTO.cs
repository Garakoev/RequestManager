using RequestManager.API.Common;
using RequestManager.Database.Models;

namespace RequestManager.API.DTOs;

public class CourierDTO : ClientEntityDTO, IMapFrom<Courier>
{
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Passport { get; set; }

    public ICollection<RequestDTO> Requests { get; set; }
}
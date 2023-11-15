using AutoMapper;
using RequestManager.API.DTOs;
using RequestManager.API.Repositories;
using RequestManager.Core.Handlers;

namespace RequestManager.API.Handlers.GetAllCouriers;

public record GetCouriersRequest;
public record GetCouriersResponse(IEnumerable<CourierDTO> Couriers);

public class GetCouriersHandler : IAsyncHandler<GetCouriersRequest, GetCouriersResponse>
{
    private readonly CourierRepository _courierRepository;
    private readonly IMapper _mapper;

    public GetCouriersHandler(CourierRepository courierRepository, IMapper mapper)
    {
        _courierRepository = courierRepository;
        _mapper = mapper;
    }

    public async Task<GetCouriersResponse> Handle(GetCouriersRequest request = null)
    {
        var couriers = await _courierRepository.GetAsync();
        var couriersDTO = couriers.Select(_mapper.Map<CourierDTO>).ToList();
        return new GetCouriersResponse(couriersDTO);
    }
}
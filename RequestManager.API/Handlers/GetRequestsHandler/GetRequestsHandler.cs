using AutoMapper;
using RequestManager.API.DTOs;
using RequestManager.API.Repositories;
using RequestManager.Core.Handlers;
using Microsoft.EntityFrameworkCore;

namespace RequestManager.API.Handlers.GetRequest;

public record GetRequestsRequest;
public record GetRequestsResponse(IEnumerable<RequestDTO> Requests);

public class GetRequestsHandler : IAsyncHandler<GetRequestsRequest, GetRequestsResponse>
{
    private readonly RequestRepository _requestRepository;
    private readonly IMapper _mapper;

    public GetRequestsHandler(RequestRepository requestRepository, IMapper mapper)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
    }

    public async Task<GetRequestsResponse> Handle(GetRequestsRequest request = null)
    {
        var requests = await _requestRepository.GetAsync(x => x.Include(x => x.Courier));
        var requestsDTO = requests.Select(_mapper.Map<RequestDTO>).ToList();

        return new GetRequestsResponse(requestsDTO);
    }
}
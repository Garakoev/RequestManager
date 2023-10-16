using AutoMapper;
using RequestManager.API.DTOs;
using RequestManager.API.Repositories;
using RequestManager.Core.Handlers;

namespace RequestManager.API.Handlers.GetRequest;

public record GetRequestsRequest;
public record GetRequestsResponse(IEnumerable<RequestDTO> Requests);

public class GetRequestHandler : IAsyncHandler<GetRequestsRequest, GetRequestsResponse>
{
    private readonly RequestRepository _requestRepository;
    private readonly IMapper _mapper;

    public GetRequestHandler(RequestRepository requestRepository, IMapper mapper)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
    }

    public async Task<GetRequestsResponse> Handle(GetRequestsRequest request)
    {
        var requests = await _requestRepository.GetAsync();
        var requestsDTO = requests.Select(_mapper.Map<RequestDTO>).ToList();

        return new GetRequestsResponse(requestsDTO);
    }
}
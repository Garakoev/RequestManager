using AutoMapper;
using RequestManager.API.DTOs;
using RequestManager.API.Repositories;
using RequestManager.Core.Handlers;
using RequestManager.Database.Models;

namespace RequestManager.API.Handlers.UpdateRequestHandler;

public record UpdateRequestRequest(RequestDTO Request);
public record UpdateRequestResponse(IEnumerable<RequestDTO> RequestDTOs);

public class UpdateRequestHandler : IAsyncHandler<UpdateRequestRequest, UpdateRequestResponse>
{
    private readonly RequestRepository _requestRepository;
    private readonly IMapper _mapper;

    public UpdateRequestHandler(RequestRepository requestRepository, IMapper mapper)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
    }

    public async Task<UpdateRequestResponse> Handle(UpdateRequestRequest requestDTO)
    {
        var request = _mapper.Map<Request>(requestDTO.Request);
        await _requestRepository.UpdateAsync(request);

        var requests = await _requestRepository.GetAsync();
        var requestDTOs = requests.Select(_mapper.Map<RequestDTO>).ToList();

        return new UpdateRequestResponse(requestDTOs);
    }
}
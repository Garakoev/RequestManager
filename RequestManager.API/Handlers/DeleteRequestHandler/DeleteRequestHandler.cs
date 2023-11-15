using AutoMapper;
using RequestManager.API.DTOs;
using RequestManager.API.Repositories;
using RequestManager.Core.Handlers;
using RequestManager.Database.Models;

namespace RequestManager.API.Handlers.DeleteRequestHandler;

public record DeleteRequestRequest(IEnumerable<RequestDTO> RequestsDTOs);
public record DeleteRequestResponse(IEnumerable<RequestDTO> RequestsDTOs);

public class DeleteRequestHandler : IAsyncHandler<DeleteRequestRequest, DeleteRequestResponse>
{
    private readonly RequestRepository _requestRepository;
    private readonly IMapper _mapper;

    public DeleteRequestHandler(RequestRepository requestRepository, IMapper mapper)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
    }

    public async Task<DeleteRequestResponse> Handle(DeleteRequestRequest requestsDTO)
    {
        var requests = requestsDTO.RequestsDTOs.Select(_mapper.Map<Request>).ToList();
        await _requestRepository.DeleteAsync(requests);

        var newRequestsList = await _requestRepository.GetAsync();
        var newRequestsDTOsList = newRequestsList.Select(_mapper.Map<RequestDTO>).ToList();

        return new DeleteRequestResponse(newRequestsDTOsList);
    }
}
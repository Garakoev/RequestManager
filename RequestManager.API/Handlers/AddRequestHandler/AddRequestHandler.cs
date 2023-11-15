using AutoMapper;
using RequestManager.API.DTOs;
using RequestManager.API.Repositories;
using RequestManager.Core.Handlers;
using RequestManager.Database.Models;

namespace RequestManager.API.Handlers.AddNewRequest;

public record AddRequestRequest(RequestDTO RequestDTO);

public record AddRequestResponse(RequestDTO RequestDTO);

public class AddRequestHandler : IAsyncHandler<AddRequestRequest, AddRequestResponse>
{
    private readonly RequestRepository _requestRepository;
    private readonly IMapper _mapper;

    public AddRequestHandler(RequestRepository requestRepository, IMapper mapper)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
    }

    public async Task<AddRequestResponse> Handle(AddRequestRequest requestDTO)
    {
        var request = _mapper.Map<Request>(requestDTO.RequestDTO);
        var requests = await _requestRepository.CreateAsync(request);
        var requestsDTO = _mapper.Map<RequestDTO>(requests);
        return new AddRequestResponse(requestsDTO);
    }
}
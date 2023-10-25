using AutoMapper;
using RequestManager.API.DTOs;
using RequestManager.API.Repositories;
using RequestManager.Core.Handlers;
using RequestManager.Database.Models;

namespace RequestManager.API.Handlers.AddNewRequest;

public record AddRequestRequest(RequestDTO Request);

public record AddRequestResponse(RequestDTO Request);

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
    {// тут потому что не было инструктций а теперь он их не создаёт
        var request = _mapper.Map<Request>(requestDTO.Request);
        var requests = await _requestRepository.CreateAsync(request);
        var requestsDTO = _mapper.Map<RequestDTO>(requests);
        return new AddRequestResponse(requestsDTO);
    }
}
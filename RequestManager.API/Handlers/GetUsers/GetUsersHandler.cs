using RequestManager.API.Repositories;
using RequestManager.Core.Handlers;

namespace RequestManager.API.Handlers.GetUsers;

public record GetUsersRequest;
public record GetUsersResponse;

public class GetUsersHandler : IAsyncHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly UserRepository _userRepository;
    public RequestRepository request;

    public GetUsersHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<GetUsersResponse> Handle(GetUsersRequest request)
    {
        return Task.FromResult(new GetUsersResponse());
    }
}
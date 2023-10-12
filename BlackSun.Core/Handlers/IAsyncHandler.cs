namespace BlackSun.Core.Handlers;

public interface IAsyncHandler<in TRequest, TResponse> : IHandler<TRequest, Task<TResponse>>
{
}
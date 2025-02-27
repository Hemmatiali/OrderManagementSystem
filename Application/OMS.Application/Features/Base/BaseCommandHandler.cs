using MediatR;

namespace OMS.Application.Features.Base;


public abstract class BaseCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            // Start process

            // Handler the request
            var response = await HandleCommand(request, cancellationToken);

            // End process
            return response;
        }
        catch (Exception ex)
        {
            // Un handled error
            throw;
        }
    }

    protected abstract Task<TResponse> HandleCommand(TRequest request, CancellationToken cancellationToken = default);
}
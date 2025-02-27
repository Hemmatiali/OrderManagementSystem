using MediatR;

namespace OMS.Application.Features.Base;

public abstract class BaseQueryHandler<TQuery> : IRequestHandler<TQuery> where TQuery : IRequest
{
    public async Task Handle(TQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            // Start process

            // Handle the query
            await HandleQuery(query, cancellationToken);

            // End process
            return;
        }
        catch (Exception ex)
        {
            // Unhandled error
            throw;
        }
    }

    protected abstract Task HandleQuery(TQuery query, CancellationToken cancellationToken);
}

public abstract class BaseQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            // Start process

            // Handle the query
            var response = await HandleQuery(query, cancellationToken);

            // End process
            return response;
        }
        catch (Exception ex)
        {
            // Unhandled error
            throw;
        }
    }

    protected abstract Task<TResponse> HandleQuery(TQuery query, CancellationToken cancellationToken);
}
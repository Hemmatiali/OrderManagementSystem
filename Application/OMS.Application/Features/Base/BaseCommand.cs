using MediatR;

namespace OMS.Application.Features.Base;

public abstract class BaseCommand<TResponse> : IRequest<TResponse>
{}

public abstract class BaseCommand : IRequest
{
}
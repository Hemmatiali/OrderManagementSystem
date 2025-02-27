using MediatR;

namespace OMS.Application.Features.Base;

public abstract class BaseQuery<T> : IRequest<T>
{ }

public abstract class BaseQuery : IRequest
{ }
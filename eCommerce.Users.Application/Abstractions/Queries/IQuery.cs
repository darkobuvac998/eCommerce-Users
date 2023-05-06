using MediatR;

namespace eCommerce.Users.Application.Abstractions.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse> { }

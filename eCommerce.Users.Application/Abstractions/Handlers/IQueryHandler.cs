using eCommerce.Users.Application.Abstractions.Queries;
using MediatR;

namespace eCommerce.Users.Application.Abstractions.Handlers;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> { }

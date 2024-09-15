namespace Domain.Interfaces.SQRS.Query;

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery
{
    Task<TResponse> HandleAsync(TQuery query);
}
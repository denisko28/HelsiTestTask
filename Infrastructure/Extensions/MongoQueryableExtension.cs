using System.Linq.Expressions;
using Application.Utils;
using Application.Utils.SortingPagination;
using Domain.Enums;
using MongoDB.Driver.Linq;

namespace Infrastructure.Extensions;

public static class MongoQueryableExtension
{
    public static IMongoQueryable<T> Sort<T>(this IMongoQueryable<T> source, ISortingModel model)
    {
        if (string.IsNullOrEmpty(model.SortingField))
            return source;

        var entityProperties = typeof(T).GetProperties();
        var sortByField = entityProperties.FirstOrDefault(p => 
            string.Equals(p.Name, model.SortingField, StringComparison.CurrentCultureIgnoreCase));

        if (sortByField == null)
            throw new ArgumentException("Incorrect sort option.");

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, sortByField.Name);
        var lambda = Expression.Lambda(property, parameter);

        return model.SortingOrder == SortingOrder.Asc 
            ? (IMongoQueryable<T>) Queryable.OrderBy(source, (dynamic)lambda) 
            : (IMongoQueryable<T>) Queryable.OrderByDescending(source, (dynamic)lambda);
    }

    public static IMongoQueryable<T> Paginate<T>(this IMongoQueryable<T> source, IPaginationModel model)
    {
        return source.Skip(model.PageNumber * model.PageSize).Take(model.PageSize);
    }
}
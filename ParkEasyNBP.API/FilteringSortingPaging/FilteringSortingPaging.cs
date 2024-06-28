using ParkEasyNBP.Domain.Interfaces;
using System.Linq.Expressions;

namespace ParkEasyNBP.API.FilteringSortingPaging
{
    public static class FilteringSortingPaging
    {
        /*public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnMaps)
        {
            if (queryObject.Filters != null)
            {
                foreach (var filter in queryObject.Filters)
                {
                    if (columnMaps.ContainsKey(filter.Key))
                    {
                        var value = filter.Value;
                        var expression = columnMaps[filter.Key];

                        // Pretpostavljamo jednostavni equal filter za primer
                        var parameter = Expression.Parameter(typeof(T), "x");
                        var member = Expression.PropertyOrField(parameter, filter.Key);
                        var constant = Expression.Constant(value);
                        var body = Expression.Equal(member, constant);
                        var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);

                        query = query.Where(predicate);
                    }
                }
            }

            return query;
        }*/

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query,
           IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnMaps)
        {
            if (!string.IsNullOrEmpty(queryObject.SortBy))
            {
                query = queryObject.IsSortAscending
                    ? query.OrderBy(columnMaps[queryObject.SortBy])
                    : query.OrderByDescending(columnMaps[queryObject.SortBy]);
            }
            return query;
        }
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObject)
        {
            if (queryObject.PageSize <= 0) queryObject.PageSize = 10;
            var count = query.Count();
            var total = count / queryObject.PageSize;
            if (queryObject.PageSize < 1 || queryObject.PageSize > total) { queryObject.Page = 1; }
            query = query.Skip(queryObject.PageSize * (queryObject.Page - 1)).Take(queryObject.PageSize);
            return query;
        }
    }
}

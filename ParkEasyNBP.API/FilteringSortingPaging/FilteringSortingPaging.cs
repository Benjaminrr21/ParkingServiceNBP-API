using ParkEasyNBP.Domain.Interfaces;
using System.Linq.Expressions;

namespace ParkEasyNBP.API.FilteringSortingPaging
{
    public static class FilteringSortingPaging
    {
        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnMaps)
        {
         throw new NotImplementedException();
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query,
            IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnMaps)
        {
            if (!string.IsNullOrEmpty(queryObject.SortBy))
            {
                // Provera da li ključ postoji u mapi
                if (columnMaps.ContainsKey(queryObject.SortBy))
                {
                    query = queryObject.IsSortAscending
                        ? query.OrderBy(columnMaps[queryObject.SortBy])
                        : query.OrderByDescending(columnMaps[queryObject.SortBy]);
                }
                else
                {
                    // Opcija 1: Vrati nesortirani upit (ili ignoriši grešku)
                    // return query;

                    // Opcija 2: Baci izuzetak ili vrati odgovor sa greškom
                    throw new ArgumentException($"Invalid sort column: {queryObject.SortBy}");
                }
            }
            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObject)
        {
            if (queryObject.PageSize <= 0) queryObject.PageSize = 10; //koliko ima na jednoj strani 
            var count = query.Count(); //broj elemenata liste 
            var total = count / queryObject.PageSize;
            if (queryObject.PageSize < 1 || queryObject.PageSize > total) { queryObject.Page = 1; }
            query = query.Skip(queryObject.PageSize * (queryObject.Page - 1)).Take(queryObject.PageSize);
            return query;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Application.Response;
public class PagingSortingFilteringList<T> : List<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public PagingSortingFilteringList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        PageSize = pageSize;
        TotalCount = count;
        AddRange(items);
    }

    public static async Task<PagingSortingFiltering<T>> CreateAsync(IEnumerable<T> source, PagingParams pagingParams)
    {
        var count = source.ToList().Count();

        var items = pagingParams.PageSize == 0
                                ? source.ToList()
                                : source.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                                    .Take(pagingParams.PageSize)
                                    .ToList();

        if (items == null) throw new Exception("Not Found");

      
        var result = new PagedList<T>(items, count, pagingParams.PageNumber, pagingParams.PageSize);

        return new PagingSortingFiltering<T>()
        {
            Items = result,
            TotalPages = result.TotalPages,
            TotalItems = result.TotalCount,
            ItemsPerPage = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }

    public static async Task<PagingSortingFiltering<T>> CreateAsyncIQueryable(IQueryable<T> source, PagingParams pagingParams)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                                .Take(pagingParams.PageSize)
                                .ToListAsync();

        if (items == null) throw new Exception("Not Found");


        var result = new PagedList<T>(items, count, pagingParams.PageNumber, pagingParams.PageSize);

        return new PagingSortingFiltering<T>()
        {
            Items = result,
            TotalPages = result.TotalPages,
            TotalItems = result.TotalCount,
            ItemsPerPage = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }
    private static object GetPropertyValue(T obj, string property)
    {
        System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
        return propertyInfo.GetValue(obj, null);
    }
}

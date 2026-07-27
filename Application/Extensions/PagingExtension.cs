using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Extensions;

public static class PagingExtension
{
    public static async Task<PagingSortingFiltering<T>> PagingAsync<T>(
        this IQueryable<T> source,
        PagingParams pagingParams)
    {
        pagingParams.PageNumber = pagingParams.PageNumber <= 0 ? 1 : pagingParams.PageNumber;
        pagingParams.PageSize = pagingParams.PageSize <= 0 ? 10 : pagingParams.PageSize;

        var count = await source.CountAsync();

        var items = await source
            .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
            .Take(pagingParams.PageSize)
            .ToListAsync();

        var result = new PagedList<T>(
            items,
            count,
            pagingParams.PageNumber,
            pagingParams.PageSize
        );

        return new PagingSortingFiltering<T>
        {
            Items = result,
            TotalPages = result.TotalPages,
            TotalItems = result.TotalCount,
            ItemsPerPage = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }

    public static async Task<PagingSortingFiltering<T>> PagingAsync<T>(
        this IQueryable<T> source,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        pageSize = pageSize <= 0 ? 10 : pageSize;

        var count = await source.CountAsync();

        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var result = new PagedList<T>(items, count, pageNumber, pageSize);

        return new PagingSortingFiltering<T>
        {
            Items = result,
            TotalPages = result.TotalPages,
            TotalItems = result.TotalCount,
            ItemsPerPage = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }

    public static async Task<PagingSortingFiltering<TDest>> PagingMappingAsync<TSource, TDest>(
           this IQueryable<TSource> source,
           PagingParams pagingParams)
    {
        pagingParams.PageNumber = pagingParams.PageNumber <= 0 ? 1 : pagingParams.PageNumber;
        pagingParams.PageSize = pagingParams.PageSize <= 0 ? 10 : pagingParams.PageSize;

        var count = await source.CountAsync();

        var items = await source
            .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
            .Take(pagingParams.PageSize)
            .ToListAsync();

        var mappedItems = items.Adapt<List<TDest>>();

        var result = new PagedList<TDest>(
            mappedItems,
            count,
            pagingParams.PageNumber,
            pagingParams.PageSize
        );

        return new PagingSortingFiltering<TDest>
        {
            Items = result,
            TotalPages = result.TotalPages,
            TotalItems = result.TotalCount,
            ItemsPerPage = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }



    public static async Task<PagingSortingFiltering<TDest>> PagingMappingAsync<TSource, TDest>(
        this IQueryable<TSource> source,
        int pageNumber,
        int pageSize)
    {
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        pageSize = pageSize <= 0 ? 10 : pageSize;

        var count = await source.CountAsync();

        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var mappedItems = items.Adapt<List<TDest>>();

        var result = new PagedList<TDest>(mappedItems, count, pageNumber, pageSize);

        return new PagingSortingFiltering<TDest>
        {
            Items = result,
            TotalPages = result.TotalPages,
            TotalItems = result.TotalCount,
            ItemsPerPage = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }
}


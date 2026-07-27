using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Application.CQRS.Partations
{
    public class GetAllPartationsQuery
      : IQuery<Result<PagingSortingFiltering<PartitionLookupResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 13;
    }

    public class GetAllPartationsQueryHandler :
        IQueryHandler<GetAllPartationsQuery,
            Result<PagingSortingFiltering<PartitionLookupResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _cache;

        public GetAllPartationsQueryHandler(IUnitOfWork unitOfWork, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Result<PagingSortingFiltering<PartitionLookupResponse>>> Handle(GetAllPartationsQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = "Partitions";

            // 1. Try to get from Cache
            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                var cachedResult = JsonSerializer.Deserialize<PagingSortingFiltering<PartitionLookupResponse>>(cachedData);
                if (cachedResult != null)
                {
                    return Result<PagingSortingFiltering<PartitionLookupResponse>>.Success(cachedResult);
                }
            }

            // 2. If not in cache, get from Database
            var query = _unitOfWork.PartitionRepository
                .GetQueryable()
                .AsNoTracking()
                .OrderBy(p => p.Id);

            var partitions = await query
                .AsSplitQuery()
                .ProjectToType<PartitionLookupResponse>()
                .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            // 3. Save to Cache 
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(8)
            };

            var serializedData = JsonSerializer.Serialize(partitions);
            await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions, cancellationToken);

            return Result<PagingSortingFiltering<PartitionLookupResponse>>.Success(partitions);
        }
    }
}


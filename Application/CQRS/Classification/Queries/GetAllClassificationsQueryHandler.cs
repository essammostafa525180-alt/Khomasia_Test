

using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Domain.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Application.CQRS.Classification.Queries
{
    public class GetAllClassificationsQuery : IQuery<Result<PagingSortingFiltering<ClassificationLookupResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = int.MaxValue;
    }

    public class GetAllClassificationsQueryHandler :
        IQueryHandler<GetAllClassificationsQuery,
            Result<PagingSortingFiltering<ClassificationLookupResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _cache;

        public GetAllClassificationsQueryHandler(IUnitOfWork unitOfWork, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Result<PagingSortingFiltering<ClassificationLookupResponse>>> Handle(
            GetAllClassificationsQuery request,
            CancellationToken cancellationToken)
        {
            string cacheKey = "Classifications";

            // 1. Try to get from Cache
            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cachedData))
            {
                var cachedResult = JsonSerializer.Deserialize<PagingSortingFiltering<ClassificationLookupResponse>>(cachedData);
                if (cachedResult != null)
                {
                    return Result<PagingSortingFiltering<ClassificationLookupResponse>>.Success(cachedResult);
                }
            }

            // 2. If not in cache, get from Database
            var classification = await _unitOfWork.ClassificationRepository.GetQueryable()
                                        .AsNoTracking()
                                        .Where(c => c.Type == ClassificationType.Classification)
                                        .OrderBy(c => c.Name)
                                        .ProjectToType<ClassificationLookupResponse>()
                                        .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            // 3. Save to Cache 
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(8)
            };

            var serializedData = JsonSerializer.Serialize(classification);
            await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions, cancellationToken);

            return Result<PagingSortingFiltering<ClassificationLookupResponse>>.Success(classification);
        }
    }
}




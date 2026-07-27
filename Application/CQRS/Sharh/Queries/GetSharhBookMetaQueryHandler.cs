using Application.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Application.CQRS.Sharh.Queries
{
    public class GetSharhBookMetaQuery : IQuery<Result<SharhBookMetaResponse>>
    {
        public int BookSharhId { get; set; }
    }

    public class GetSharhBookMetaQueryHandler
         : IQueryHandler<GetSharhBookMetaQuery, Result<SharhBookMetaResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _cache;

        private static readonly DistributedCacheEntryOptions CacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
        };

        public GetSharhBookMetaQueryHandler(IUnitOfWork unitOfWork, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<Result<SharhBookMetaResponse>> Handle(
            GetSharhBookMetaQuery request,
            CancellationToken cancellationToken)
        {
            var cacheKey = $"sharh-book-meta:{request.BookSharhId}";

            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (cachedData is not null)
            {
                var cachedResponse = JsonSerializer.Deserialize<SharhBookMetaResponse>(cachedData);
                return Result<SharhBookMetaResponse>.Success(cachedResponse!);
            }

            var response = await _unitOfWork.SharhBookRepository
                .GetQueryable()
                .AsNoTracking()
                .Where(sb => sb.Id == request.BookSharhId)
                .OrderBy(h => h.Id)
                .ProjectToType<SharhBookMetaResponse>()
                .FirstOrDefaultAsync(cancellationToken);



            var (bookName, authorName) = ParseBookNameAndAuthor(response.SharhBookName);
            response.SharhBookName = bookName;
            response.SharhBookAuthor = authorName;


            if (response is null)
                return Result<SharhBookMetaResponse>.Failure(Errors.SharhNotFound);

            var serialized = JsonSerializer.Serialize(response);
            await _cache.SetStringAsync(cacheKey, serialized, CacheOptions, cancellationToken);

            return Result<SharhBookMetaResponse>.Success(response);
        }

        private static (string BookName, string AuthorName) ParseBookNameAndAuthor(string rawName)
        {
            if (string.IsNullOrWhiteSpace(rawName))
                return (string.Empty, string.Empty);

            var cleaned = rawName.Replace("|", "").Trim();
            var lines = cleaned.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            string bookName = string.Empty;
            string authorName = string.Empty;

            if (lines.Length > 0)
            {
                var firstLine = lines[0].Trim();
                const string bookPrefix = "كتاب";
                const string stopWord = "شرح";

                var startIndex = firstLine.StartsWith(bookPrefix) ? bookPrefix.Length : 0;
                var stopIndex = firstLine.IndexOf(stopWord, startIndex, StringComparison.Ordinal);

                bookName = stopIndex == -1
                    ? firstLine.Substring(startIndex).Trim()
                    : firstLine.Substring(startIndex, stopIndex - startIndex).Trim();
            }

            if (lines.Length > 1)
            {
                var secondLine = lines[1].Trim();
                const string authorPrefix = "للحافظ";

                authorName = secondLine.StartsWith(authorPrefix)
                    ? secondLine.Substring(authorPrefix.Length).Trim()
                    : secondLine;
            }

            return (bookName, authorName);
        }
    }
}
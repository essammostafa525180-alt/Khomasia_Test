using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Sharh.Queries
{
    public class GetAllBabSharhQuery
 : IQuery<Result<List<SharhBabListResponse>>>
    {
        public int BabId { get; set; }
        public int BookId { get; set; }

    }
    public class GetAllBabSharhQueryHandler :
        IQueryHandler<GetAllBabSharhQuery,
            Result<List<SharhBabListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBabSharhQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<SharhBabListResponse>>> Handle(
       GetAllBabSharhQuery request,
       CancellationToken cancellationToken)
        {
            var sharhQuery = _unitOfWork.HadithSharhRepository
                   .GetQueryable()
                   .AsNoTracking()
                   .Where(s => s.BookSharhId == request.BookId && s.BabId == request.BabId);

            var sharhMissingQuery = _unitOfWork.HadithSharhMissingRepository
                .GetQueryable()
                .AsNoTracking()
                .Where(s => s.BookSharhId == request.BookId && s.BabId == request.BabId);

            var result = await sharhQuery
                .Select(s => new
                {
                    s.HadithNumber,
                    s.SharhWithSign,
                    s.SharhWithNoSign,
                    s.HadithId
                })
                .Concat(
                    sharhMissingQuery.Select(s => new
                    {
                        s.HadithNumber,
                        s.SharhWithSign,
                        s.SharhWithNoSign,
                        s.HadithId
                    })
                )
                .OrderBy(s => s.HadithId)
                .Select(s => new SharhBabListResponse(
                    s.HadithNumber,
                    s.SharhWithSign,
                    s.SharhWithNoSign,
                    s.HadithId
                ))
                  .AsSplitQuery()

                .ToListAsync(cancellationToken);


            if (!result.Any())
                return Result<List<SharhBabListResponse>>.Failure(Errors.SharhNotFound);

            return Result<List<SharhBabListResponse>>.Success(result);
        }

    }
}



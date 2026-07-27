using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Sharh.Queries
{
    public class GetBookSharhByHadithIdQuery
: IQuery<Result<List<HadithSharhListResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int HadithId { get; set; }
    }
    public class GetBookSharhByHadithIdQueryHandler
         : IQueryHandler<GetBookSharhByHadithIdQuery, Result<List<HadithSharhListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookSharhByHadithIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<HadithSharhListResponse>>> Handle(
            GetBookSharhByHadithIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.HadithSharhRepository
    .GetQueryable()
    .AsNoTracking()
    .Include(s => s.SharhBook)
    .Where(s => s.HadithId == request.HadithId)
    .GroupBy(s => new { s.SharhBook.Id, s.SharhBook.Name })
    .Select(g => new HadithSharhListResponse(
        g.Key.Id, // BookId
        g.Key.Name, // BookName
        g.Select(s => s.SharhWithSign).Where(x => x != null).ToList(),
        g.Select(s => s.SharhWithNoSign).Where(x => x != null).ToList()
    ))

    .ToListAsync(cancellationToken);


            if (result is null)
                return Result<List<HadithSharhListResponse>>.Failure(Errors.SharhNotFound);
            //var result = sharhBooks.Adapt<List<HadithSharhListResponse>>();


            return Result<List<HadithSharhListResponse>>.Success(result);
        }
    }
}



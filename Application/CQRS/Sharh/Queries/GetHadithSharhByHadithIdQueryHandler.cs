using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Sharh.Queries
{
    public class GetHadithSharhByHadithIdQuery
: IQuery<Result<HadithSharhListResponse>>
    {

        public int BookId { get; set; }
        public int HadithId { get; set; }
    }
    public class GetHadithSharhByHadithIdQueryHandler
         : IQueryHandler<GetHadithSharhByHadithIdQuery, Result<HadithSharhListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHadithSharhByHadithIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<HadithSharhListResponse>> Handle(
            GetHadithSharhByHadithIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.HadithSharhRepository
    .GetQueryable()
    .AsNoTracking()
    .Include(s => s.SharhBook)
    .Where(s => s.SharhBook.Id == request.BookId && s.HadithId == request.HadithId)
    .GroupBy(s => new { s.SharhBook.Id, s.SharhBook.Name })
    .Select(g => new HadithSharhListResponse(
        g.Key.Id, // BookId
        g.Key.Name, // BookName
        g.Select(s => s.SharhWithSign).Where(x => x != null).ToList(),
        g.Select(s => s.SharhWithNoSign).Where(x => x != null).ToList()
    ))
    .FirstOrDefaultAsync(cancellationToken);


            if (result is null)
                return Result<HadithSharhListResponse>.Failure(Errors.SharhNotFound);
            //var result = sharhBooks.Adapt<<HadithSharhListResponse>>();


            return Result<HadithSharhListResponse>.Success(result);
        }
    }
}



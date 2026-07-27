using Application.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Sharh.Queries
{
    public class GetBookSharhByClassificationIdQuery
  : IQuery<Result<ClassificationWithBookSharhListResponse>>
    {
        public int ClassificationId { get; set; }

    }
    public class GetBookSharhByClassificationIdQueryHandler :
        IQueryHandler<GetBookSharhByClassificationIdQuery,
            Result<ClassificationWithBookSharhListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookSharhByClassificationIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ClassificationWithBookSharhListResponse>> Handle(
            GetBookSharhByClassificationIdQuery request,
            CancellationToken cancellationToken)
        {
            var sharhBook = await _unitOfWork.ClassificationRepository
                  .GetQueryable()
                  .AsNoTracking()
                  .Where(h => h.Id == request.ClassificationId)
                  .ProjectToType<ClassificationWithBookSharhListResponse>()
                  .FirstOrDefaultAsync(cancellationToken);

            if (sharhBook is null)
                return Result<ClassificationWithBookSharhListResponse>.Failure(Errors.ClassificationNotFound);

            return Result<ClassificationWithBookSharhListResponse>.Success(sharhBook);
        }
    }
}




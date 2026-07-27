using Application.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Classification.Queries
{
    public class GetClassificationByIdQuery
: IQuery<Result<ClassificationSummaryResponse>>
    {
        public int Id { get; set; }
    }
    public class GetClassificationByIdQueryHandler
         : IQueryHandler<GetClassificationByIdQuery, Result<ClassificationSummaryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClassificationByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ClassificationSummaryResponse>> Handle(
            GetClassificationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var classification = await _unitOfWork.ClassificationRepository.GetQueryable()
                .Include(b => b.Books)
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (classification is null)
                return Result<ClassificationSummaryResponse>.Failure(Errors.ClassificationNotFound);

            var response = classification.Adapt<ClassificationSummaryResponse>();

            return Result<ClassificationSummaryResponse>.Success(response);
        }
    }
}






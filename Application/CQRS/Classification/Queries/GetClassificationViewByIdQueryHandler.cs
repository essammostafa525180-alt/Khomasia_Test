using Application.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Classification.Queries
{
    public class GetClassificationViewByIdQuery
: IQuery<Result<ClassificationSummary>>
    {
        public int Id { get; set; }
    }
    public class GetClassificationViewByIdQueryHandler
         : IQueryHandler<GetClassificationViewByIdQuery, Result<ClassificationSummary>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClassificationViewByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ClassificationSummary>> Handle(
            GetClassificationViewByIdQuery request,
            CancellationToken cancellationToken)
        {
            var classification = await _unitOfWork.ClassificationRepository.GetQueryable()
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (classification is null)
                return Result<ClassificationSummary>.Failure(Errors.ClassificationNotFound);
            var response = classification.Adapt<ClassificationSummary>();


            return Result<ClassificationSummary>.Success(response);
        }
    }
}
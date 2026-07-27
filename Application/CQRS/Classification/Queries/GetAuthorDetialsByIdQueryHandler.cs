using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Classification.Queries
{
    public class GetAuthorDetialsByIdQuery
: IQuery<Result<ClassificationDetailsResponse>>
    {
        public int Id { get; set; }
    }
    public class GetAuthorDetialsByIdQueryHandler
         : IQueryHandler<GetAuthorDetialsByIdQuery, Result<ClassificationDetailsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAuthorDetialsByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ClassificationDetailsResponse>> Handle(
            GetAuthorDetialsByIdQuery request,
            CancellationToken cancellationToken)
        {
            var classification = await _unitOfWork.ClassificationRepository.GetByIdAsync(request.Id);

            if (classification is null)
                return Result<ClassificationDetailsResponse>.Failure(Errors.ClassificationNotFound);

            var response = classification.Adapt<ClassificationDetailsResponse>();

            return Result<ClassificationDetailsResponse>.Success(response);
        }
    }
}






using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Partations.Queries
{
    public class GetPartationByIdQuery
: IQuery<Result<PartitionDetailsResponse>>
    {
        public int Id { get; set; }
    }
    public class GetPartationByIdQueryHandler
         : IQueryHandler<GetPartationByIdQuery, Result<PartitionDetailsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPartationByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PartitionDetailsResponse>> Handle(
            GetPartationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var partation = await _unitOfWork.PartitionRepository
                .GetByIdAsync(request.Id);

            if (partation is null)
                return Result<PartitionDetailsResponse>.Failure(Errors.PartitionNotFound);

            var response = partation.Adapt<PartitionDetailsResponse>();

            return Result<PartitionDetailsResponse>.Success(response);
        }
    }
}






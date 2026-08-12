using Application.Abstractions;
using Mapster;

namespace Application.CQRS.RwDeliveredBatch.Queries;

public class GetRwDeliveredBatchByIdQuery : IQuery<Result<RwDeliveredBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetRwDeliveredBatchByIdQueryHandler : IQueryHandler<GetRwDeliveredBatchByIdQuery, Result<RwDeliveredBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRwDeliveredBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RwDeliveredBatchDetailsResponse>> Handle(GetRwDeliveredBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<RwDeliveredBatchDetailsResponse>.Failure(Errors.RwDeliveredBatchNotFound);

        var response = entity.Adapt<RwDeliveredBatchDetailsResponse>();

        return Result<RwDeliveredBatchDetailsResponse>.Success(response);
    }
}
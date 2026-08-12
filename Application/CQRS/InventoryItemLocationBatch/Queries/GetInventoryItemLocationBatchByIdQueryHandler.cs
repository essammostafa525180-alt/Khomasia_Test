using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemLocationBatch.Queries;

public class GetInventoryItemLocationBatchByIdQuery : IQuery<Result<InventoryItemLocationBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemLocationBatchByIdQueryHandler : IQueryHandler<GetInventoryItemLocationBatchByIdQuery, Result<InventoryItemLocationBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemLocationBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemLocationBatchDetailsResponse>> Handle(GetInventoryItemLocationBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemLocationBatchDetailsResponse>.Failure(Errors.InventoryItemLocationBatchNotFound);

        var response = entity.Adapt<InventoryItemLocationBatchDetailsResponse>();

        return Result<InventoryItemLocationBatchDetailsResponse>.Success(response);
    }
}
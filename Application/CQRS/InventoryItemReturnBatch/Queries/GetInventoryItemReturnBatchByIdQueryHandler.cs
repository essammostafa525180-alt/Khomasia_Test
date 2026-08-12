using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemReturnBatch.Queries;

public class GetInventoryItemReturnBatchByIdQuery : IQuery<Result<InventoryItemReturnBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemReturnBatchByIdQueryHandler : IQueryHandler<GetInventoryItemReturnBatchByIdQuery, Result<InventoryItemReturnBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemReturnBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemReturnBatchDetailsResponse>> Handle(GetInventoryItemReturnBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemReturnBatchDetailsResponse>.Failure(Errors.InventoryItemReturnBatchNotFound);

        var response = entity.Adapt<InventoryItemReturnBatchDetailsResponse>();

        return Result<InventoryItemReturnBatchDetailsResponse>.Success(response);
    }
}
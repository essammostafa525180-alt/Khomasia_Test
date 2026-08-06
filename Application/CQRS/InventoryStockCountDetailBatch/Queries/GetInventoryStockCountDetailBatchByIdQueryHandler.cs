using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryStockCountDetailBatch.Queries;

public class GetInventoryStockCountDetailBatchByIdQuery : IQuery<Result<InventoryStockCountDetailBatchDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryStockCountDetailBatchByIdQueryHandler : IQueryHandler<GetInventoryStockCountDetailBatchByIdQuery, Result<InventoryStockCountDetailBatchDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryStockCountDetailBatchByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryStockCountDetailBatchDetailsResponse>> Handle(GetInventoryStockCountDetailBatchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryStockCountDetailBatchDetailsResponse>.Failure(Errors.InventoryStockCountDetailBatchNotFound);

        var response = entity.Adapt<InventoryStockCountDetailBatchDetailsResponse>();

        return Result<InventoryStockCountDetailBatchDetailsResponse>.Success(response);
    }
}
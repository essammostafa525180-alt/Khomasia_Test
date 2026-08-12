using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryStockCountDetailBatchSerial.Queries;

public class GetInventoryStockCountDetailBatchSerialByIdQuery : IQuery<Result<InventoryStockCountDetailBatchSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryStockCountDetailBatchSerialByIdQueryHandler : IQueryHandler<GetInventoryStockCountDetailBatchSerialByIdQuery, Result<InventoryStockCountDetailBatchSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryStockCountDetailBatchSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryStockCountDetailBatchSerialDetailsResponse>> Handle(GetInventoryStockCountDetailBatchSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryStockCountDetailBatchSerialDetailsResponse>.Failure(Errors.InventoryStockCountDetailBatchSerialNotFound);

        var response = entity.Adapt<InventoryStockCountDetailBatchSerialDetailsResponse>();

        return Result<InventoryStockCountDetailBatchSerialDetailsResponse>.Success(response);
    }
}
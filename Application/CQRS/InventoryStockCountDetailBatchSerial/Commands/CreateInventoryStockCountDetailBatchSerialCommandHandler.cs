using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetailBatchSerial.Commands;

public class CreateInventoryStockCountDetailBatchSerialCommand : ICommand<Result<int>>
{
        public int? InventoryStockCountDetailBatchFk { get; set; }
        public int? InventoryItemLocationBatchSerialFk { get; set; }
        public bool IsNew { get; set; }
        public bool IsSerialExist { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryStockCountDetailBatchSerialCommandHandler : ICommandHandler<CreateInventoryStockCountDetailBatchSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryStockCountDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryStockCountDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.InventoryStockCountDetailBatchSerial.Create(request.InventoryStockCountDetailBatchFk, request.InventoryItemLocationBatchSerialFk, request.IsNew, request.IsSerialExist, request.IsActive);

        await _unitOfWork.InventoryStockCountDetailBatchSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryStockCountDetailBatchSerialNotInserted);
    }
}
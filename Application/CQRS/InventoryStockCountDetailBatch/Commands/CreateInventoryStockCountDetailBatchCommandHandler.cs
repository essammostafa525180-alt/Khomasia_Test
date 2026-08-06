using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetailBatch.Commands;

public class CreateInventoryStockCountDetailBatchCommand : ICommand<Result<int>>
{
        public int? InventoryStockCountDetailFk { get; set; }
        public int? BatchFk { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? CountQuantity { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryStockCountDetailBatchCommandHandler : ICommandHandler<CreateInventoryStockCountDetailBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryStockCountDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryStockCountDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.InventoryStockCountDetailBatch.Create(request.InventoryStockCountDetailFk, request.BatchFk, request.Quantity, request.CountQuantity, request.IsActive);

        await _unitOfWork.InventoryStockCountDetailBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryStockCountDetailBatchNotInserted);
    }
}
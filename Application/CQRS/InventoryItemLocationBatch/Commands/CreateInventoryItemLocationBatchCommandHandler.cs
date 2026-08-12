using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationBatch.Commands;

public class CreateInventoryItemLocationBatchCommand : ICommand<Result<int>>
{
        public int? InventoryItemLocationFk { get; set; }
        public string? BatchNumber { get; set; }
        public int? ShelfFk { get; set; }
        public decimal? TotalQuantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? InventoryItemFk { get; set; }
        public DateTime? ProductionDate { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemLocationBatchCommandHandler : ICommandHandler<CreateInventoryItemLocationBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemLocationBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemLocationBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemLocationBatch.Create(request.InventoryItemLocationFk, request.BatchNumber, request.ShelfFk, request.TotalQuantity, request.ExpiryDate, request.InventoryItemFk, request.ProductionDate, request.IsActive);

        await _unitOfWork.InventoryItemLocationBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemLocationBatchNotInserted);
    }
}
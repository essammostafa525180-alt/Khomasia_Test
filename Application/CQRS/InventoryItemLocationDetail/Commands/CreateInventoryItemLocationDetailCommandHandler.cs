using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationDetail.Commands;

public class CreateInventoryItemLocationDetailCommand : ICommand<Result<int>>
{
        public int? StoreFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? ItemQuantityTypeFk { get; set; }
        public int? TransactionTypeFk { get; set; }
        public string? Screen { get; set; }
        public int? EntityId { get; set; }
        public string? EntityCode { get; set; }
        public DateTime? EntityDate { get; set; }
        public int? EntityDetailId { get; set; }
        public int? InventoryItemLocationFk { get; set; }
        public decimal? QuantityBefore { get; set; }
        public decimal Quantity { get; set; }
        public decimal? QuantityAfter { get; set; }
        public decimal? EntityDetailCost { get; set; }
        public decimal? Avgcost { get; set; }
        public int? InventoryItemLocationBatchFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemLocationDetailCommandHandler : ICommandHandler<CreateInventoryItemLocationDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemLocationDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemLocationDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemLocationDetail.Create(request.StoreFk, request.InventoryItemFk, request.ItemQuantityTypeFk, request.TransactionTypeFk, request.Screen, request.EntityId, request.EntityCode, request.EntityDate, request.EntityDetailId, request.InventoryItemLocationFk, request.QuantityBefore, request.Quantity, request.QuantityAfter, request.EntityDetailCost, request.Avgcost, request.InventoryItemLocationBatchFk, request.IsActive);

        await _unitOfWork.InventoryItemLocationDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemLocationDetailNotInserted);
    }
}
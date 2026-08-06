using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationDetail.Commands;

public class UpdateInventoryItemLocationDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateInventoryItemLocationDetailCommandHandler : ICommandHandler<UpdateInventoryItemLocationDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemLocationDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemLocationDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemLocationDetailNotFound);

        entity.Update(request.StoreFk, request.InventoryItemFk, request.ItemQuantityTypeFk, request.TransactionTypeFk, request.Screen, request.EntityId, request.EntityCode, request.EntityDate, request.EntityDetailId, request.InventoryItemLocationFk, request.QuantityBefore, request.Quantity, request.QuantityAfter, request.EntityDetailCost, request.Avgcost, request.InventoryItemLocationBatchFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemLocationDetailNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetail.Commands;

public class UpdateInventoryStockCountDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? CountQuantity { get; set; }
        public string? IncDecReason { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryStockCountDetailCommandHandler : ICommandHandler<UpdateInventoryStockCountDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryStockCountDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryStockCountDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountDetailNotFound);

        entity.Update(request.InventoryStockCountFk, request.InventoryItemFk, request.Quantity, request.CountQuantity, request.IncDecReason, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountDetailNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.Oil.Commands;

public class UpdateOilCommand : ICommand<Result>
{
        public int Id { get; set; }
        public double? StoreId { get; set; }
        public string? StoreName { get; set; }
        public DateTime? StockCountDate { get; set; }
        public double? InventoryItemId { get; set; }
        public string? InventoryItemCode { get; set; }
        public string? InventoryItemName { get; set; }
        public double? AvgCost { get; set; }
        public double? TotalQuantity { get; set; }
        public double? StockCountQuantity { get; set; }
        public double? Mmbalance { get; set; }
        public string? IsMatch { get; set; }
        public double? IsUpdated { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateOilCommandHandler : ICommandHandler<UpdateOilCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOilCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateOilCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OilRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.OilNotFound);

        entity.Update(request.StoreId, request.StoreName, request.StockCountDate, request.InventoryItemId, request.InventoryItemCode, request.InventoryItemName, request.AvgCost, request.TotalQuantity, request.StockCountQuantity, request.Mmbalance, request.IsMatch, request.IsUpdated, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.OilNotUpdated);
    }
}
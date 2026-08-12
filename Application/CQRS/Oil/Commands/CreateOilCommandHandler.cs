using Application.Abstractions;

namespace Application.CQRS.Oil.Commands;

public class CreateOilCommand : ICommand<Result<int>>
{
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
internal class CreateOilCommandHandler : ICommandHandler<CreateOilCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOilCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateOilCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.Oil.Create(request.StoreId, request.StoreName, request.StockCountDate, request.InventoryItemId, request.InventoryItemCode, request.InventoryItemName, request.AvgCost, request.TotalQuantity, request.StockCountQuantity, request.Mmbalance, request.IsMatch, request.IsUpdated, request.IsActive);

        await _unitOfWork.OilRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.OilNotInserted);
    }
}
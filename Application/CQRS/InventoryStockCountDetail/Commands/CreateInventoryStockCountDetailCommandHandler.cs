using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetail.Commands;

public class CreateInventoryStockCountDetailCommand : ICommand<Result<int>>
{
        public int? InventoryStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? CountQuantity { get; set; }
        public string? IncDecReason { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryStockCountDetailCommandHandler : ICommandHandler<CreateInventoryStockCountDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryStockCountDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryStockCountDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.InventoryStockCountDetail.Create(request.InventoryStockCountFk, request.InventoryItemFk, request.Quantity, request.CountQuantity, request.IncDecReason, request.IsActive);

        await _unitOfWork.InventoryStockCountDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryStockCountDetailNotInserted);
    }
}
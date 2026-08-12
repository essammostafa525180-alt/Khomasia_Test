using Application.Abstractions;

namespace Application.CQRS.InventoryItemCost.Commands;

public class CreateInventoryItemCostCommand : ICommand<Result<int>>
{
        public long? InventoryItemFk { get; set; }
        public int? CompanyFk { get; set; }
        public decimal? AvgCost { get; set; }
        public decimal? TotalQuantity { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemCostCommandHandler : ICommandHandler<CreateInventoryItemCostCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemCostCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemCostCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemCost.Create(request.InventoryItemFk, request.CompanyFk, request.AvgCost, request.TotalQuantity, request.IsActive);

        await _unitOfWork.InventoryItemCostRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemCostNotInserted);
    }
}
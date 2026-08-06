using Application.Abstractions;

namespace Application.CQRS.InventoryItemBudgetDetail.Commands;

public class CreateInventoryItemBudgetDetailCommand : ICommand<Result<int>>
{
        public int? InventoryItemBudgetFk { get; set; }
        public int? ItemTypeFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? BudgetQuantity { get; set; }
        public decimal? BudgetCost { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemBudgetDetailCommandHandler : ICommandHandler<CreateInventoryItemBudgetDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemBudgetDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemBudgetDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemBudgetDetail.Create(request.InventoryItemBudgetFk, request.ItemTypeFk, request.InventoryItemFk, request.BudgetQuantity, request.BudgetCost, request.IsActive);

        await _unitOfWork.InventoryItemBudgetDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemBudgetDetailNotInserted);
    }
}
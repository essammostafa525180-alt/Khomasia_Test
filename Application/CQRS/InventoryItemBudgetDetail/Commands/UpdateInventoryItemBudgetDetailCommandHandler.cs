using Application.Abstractions;

namespace Application.CQRS.InventoryItemBudgetDetail.Commands;

public class UpdateInventoryItemBudgetDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryItemBudgetFk { get; set; }
        public int? ItemTypeFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? BudgetQuantity { get; set; }
        public decimal? BudgetCost { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemBudgetDetailCommandHandler : ICommandHandler<UpdateInventoryItemBudgetDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemBudgetDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemBudgetDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemBudgetDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemBudgetDetailNotFound);

        entity.Update(request.InventoryItemBudgetFk, request.ItemTypeFk, request.InventoryItemFk, request.BudgetQuantity, request.BudgetCost, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemBudgetDetailNotUpdated);
    }
}
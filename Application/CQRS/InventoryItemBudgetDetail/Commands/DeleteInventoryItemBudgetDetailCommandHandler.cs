using Application.Abstractions;

namespace Application.CQRS.InventoryItemBudgetDetail.Commands;

public class DeleteInventoryItemBudgetDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemBudgetDetailCommandHandler : ICommandHandler<DeleteInventoryItemBudgetDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemBudgetDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemBudgetDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemBudgetDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemBudgetDetailNotFound);

        _unitOfWork.InventoryItemBudgetDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemBudgetDetailNotDeleted);
    }
}
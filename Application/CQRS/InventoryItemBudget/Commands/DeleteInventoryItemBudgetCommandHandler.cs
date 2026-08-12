using Application.Abstractions;

namespace Application.CQRS.InventoryItemBudget.Commands;

public class DeleteInventoryItemBudgetCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemBudgetCommandHandler : ICommandHandler<DeleteInventoryItemBudgetCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemBudgetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemBudgetCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemBudgetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemBudgetNotFound);

        _unitOfWork.InventoryItemBudgetRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemBudgetNotDeleted);
    }
}
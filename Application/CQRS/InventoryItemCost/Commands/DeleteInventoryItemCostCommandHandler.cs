using Application.Abstractions;

namespace Application.CQRS.InventoryItemCost.Commands;

public class DeleteInventoryItemCostCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemCostCommandHandler : ICommandHandler<DeleteInventoryItemCostCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemCostCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemCostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemCostRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemCostNotFound);

        _unitOfWork.InventoryItemCostRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemCostNotDeleted);
    }
}
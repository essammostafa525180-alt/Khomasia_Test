using Application.Abstractions;

namespace Application.CQRS.InventoryItemTransactionType.Commands;

public class DeleteInventoryItemTransactionTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemTransactionTypeCommandHandler : ICommandHandler<DeleteInventoryItemTransactionTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemTransactionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemTransactionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemTransactionTypeNotFound);

        _unitOfWork.InventoryItemTransactionTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemTransactionTypeNotDeleted);
    }
}
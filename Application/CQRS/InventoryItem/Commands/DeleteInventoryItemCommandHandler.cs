using Application.Abstractions;

namespace Application.CQRS.InventoryItem.Commands;

public class DeleteInventoryItemCommand : ICommand<Result>
{
    public long Id { get; set; }
}
internal class DeleteInventoryItemCommandHandler : ICommandHandler<DeleteInventoryItemCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemNotFound);

        _unitOfWork.InventoryItemRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemNotDeleted);
    }
}
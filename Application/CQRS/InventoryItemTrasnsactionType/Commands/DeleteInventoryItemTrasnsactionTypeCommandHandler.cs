using Application.Abstractions;

namespace Application.CQRS.InventoryItemTrasnsactionType.Commands;

public class DeleteInventoryItemTrasnsactionTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemTrasnsactionTypeCommandHandler : ICommandHandler<DeleteInventoryItemTrasnsactionTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemTrasnsactionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemTrasnsactionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemTrasnsactionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemTrasnsactionTypeNotFound);

        _unitOfWork.InventoryItemTrasnsactionTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemTrasnsactionTypeNotDeleted);
    }
}
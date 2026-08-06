using Application.Abstractions;

namespace Application.CQRS.InventoryItemUoM.Commands;

public class DeleteInventoryItemUoMCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemUoMCommandHandler : ICommandHandler<DeleteInventoryItemUoMCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemUoMCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemUoMCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemUoMRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemUoMNotFound);

        _unitOfWork.InventoryItemUoMRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemUoMNotDeleted);
    }
}
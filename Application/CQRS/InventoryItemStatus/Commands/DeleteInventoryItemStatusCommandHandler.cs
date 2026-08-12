using Application.Abstractions;

namespace Application.CQRS.InventoryItemStatus.Commands;

public class DeleteInventoryItemStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemStatusCommandHandler : ICommandHandler<DeleteInventoryItemStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemStatusNotFound);

        _unitOfWork.InventoryItemStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemStatusNotDeleted);
    }
}
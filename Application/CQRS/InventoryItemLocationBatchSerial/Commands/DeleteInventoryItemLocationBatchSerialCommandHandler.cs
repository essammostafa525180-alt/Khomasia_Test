using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationBatchSerial.Commands;

public class DeleteInventoryItemLocationBatchSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemLocationBatchSerialCommandHandler : ICommandHandler<DeleteInventoryItemLocationBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemLocationBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemLocationBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemLocationBatchSerialNotFound);

        _unitOfWork.InventoryItemLocationBatchSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemLocationBatchSerialNotDeleted);
    }
}
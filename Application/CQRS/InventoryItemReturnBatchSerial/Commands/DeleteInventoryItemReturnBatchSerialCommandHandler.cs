using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnBatchSerial.Commands;

public class DeleteInventoryItemReturnBatchSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemReturnBatchSerialCommandHandler : ICommandHandler<DeleteInventoryItemReturnBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemReturnBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemReturnBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnBatchSerialNotFound);

        _unitOfWork.InventoryItemReturnBatchSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnBatchSerialNotDeleted);
    }
}
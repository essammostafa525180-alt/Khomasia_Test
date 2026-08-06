using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetailBatchSerial.Commands;

public class DeleteInventoryTransfereDetailBatchSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryTransfereDetailBatchSerialCommandHandler : ICommandHandler<DeleteInventoryTransfereDetailBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryTransfereDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryTransfereDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereDetailBatchSerialNotFound);

        _unitOfWork.InventoryTransfereDetailBatchSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereDetailBatchSerialNotDeleted);
    }
}
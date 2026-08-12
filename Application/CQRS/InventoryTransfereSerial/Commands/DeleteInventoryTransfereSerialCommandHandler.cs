using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereSerial.Commands;

public class DeleteInventoryTransfereSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryTransfereSerialCommandHandler : ICommandHandler<DeleteInventoryTransfereSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryTransfereSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryTransfereSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereSerialNotFound);

        _unitOfWork.InventoryTransfereSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereSerialNotDeleted);
    }
}
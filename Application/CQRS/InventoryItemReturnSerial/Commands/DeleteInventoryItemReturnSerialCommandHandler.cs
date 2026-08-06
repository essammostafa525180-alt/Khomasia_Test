using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnSerial.Commands;

public class DeleteInventoryItemReturnSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemReturnSerialCommandHandler : ICommandHandler<DeleteInventoryItemReturnSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemReturnSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemReturnSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnSerialNotFound);

        _unitOfWork.InventoryItemReturnSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnSerialNotDeleted);
    }
}
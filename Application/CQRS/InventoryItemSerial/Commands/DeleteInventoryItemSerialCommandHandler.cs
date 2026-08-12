using Application.Abstractions;

namespace Application.CQRS.InventoryItemSerial.Commands;

public class DeleteInventoryItemSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemSerialCommandHandler : ICommandHandler<DeleteInventoryItemSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemSerialNotFound);

        _unitOfWork.InventoryItemSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemSerialNotDeleted);
    }
}
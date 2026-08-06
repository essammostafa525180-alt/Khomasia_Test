using Application.Abstractions;

namespace Application.CQRS.InventoryItemSerialStatus.Commands;

public class DeleteInventoryItemSerialStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemSerialStatusCommandHandler : ICommandHandler<DeleteInventoryItemSerialStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemSerialStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemSerialStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemSerialStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemSerialStatusNotFound);

        _unitOfWork.InventoryItemSerialStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemSerialStatusNotDeleted);
    }
}
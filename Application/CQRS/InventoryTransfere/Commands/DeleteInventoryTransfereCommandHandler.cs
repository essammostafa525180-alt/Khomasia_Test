using Application.Abstractions;

namespace Application.CQRS.InventoryTransfere.Commands;

public class DeleteInventoryTransfereCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryTransfereCommandHandler : ICommandHandler<DeleteInventoryTransfereCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryTransfereCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryTransfereCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereNotFound);

        _unitOfWork.InventoryTransfereRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereNotDeleted);
    }
}
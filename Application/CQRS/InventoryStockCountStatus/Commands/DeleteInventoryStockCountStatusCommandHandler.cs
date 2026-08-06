using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountStatus.Commands;

public class DeleteInventoryStockCountStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryStockCountStatusCommandHandler : ICommandHandler<DeleteInventoryStockCountStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryStockCountStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryStockCountStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountStatusNotFound);

        _unitOfWork.InventoryStockCountStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountStatusNotDeleted);
    }
}
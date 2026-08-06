using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetail.Commands;

public class DeleteInventoryStockCountDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryStockCountDetailCommandHandler : ICommandHandler<DeleteInventoryStockCountDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryStockCountDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryStockCountDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountDetailNotFound);

        _unitOfWork.InventoryStockCountDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountDetailNotDeleted);
    }
}
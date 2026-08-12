using Application.Abstractions;

namespace Application.CQRS.InventoryStockCount.Commands;

public class DeleteInventoryStockCountCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryStockCountCommandHandler : ICommandHandler<DeleteInventoryStockCountCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryStockCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryStockCountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountNotFound);

        _unitOfWork.InventoryStockCountRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountNotDeleted);
    }
}
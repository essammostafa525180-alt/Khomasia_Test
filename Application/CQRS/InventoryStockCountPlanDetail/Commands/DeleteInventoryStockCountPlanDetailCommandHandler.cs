using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountPlanDetail.Commands;

public class DeleteInventoryStockCountPlanDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryStockCountPlanDetailCommandHandler : ICommandHandler<DeleteInventoryStockCountPlanDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryStockCountPlanDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryStockCountPlanDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountPlanDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountPlanDetailNotFound);

        _unitOfWork.InventoryStockCountPlanDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountPlanDetailNotDeleted);
    }
}
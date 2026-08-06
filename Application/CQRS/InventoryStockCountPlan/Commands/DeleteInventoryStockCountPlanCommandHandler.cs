using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountPlan.Commands;

public class DeleteInventoryStockCountPlanCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryStockCountPlanCommandHandler : ICommandHandler<DeleteInventoryStockCountPlanCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryStockCountPlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryStockCountPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountPlanRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountPlanNotFound);

        _unitOfWork.InventoryStockCountPlanRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountPlanNotDeleted);
    }
}
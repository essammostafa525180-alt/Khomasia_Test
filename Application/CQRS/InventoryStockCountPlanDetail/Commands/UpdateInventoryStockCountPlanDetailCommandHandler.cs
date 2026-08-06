using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountPlanDetail.Commands;

public class UpdateInventoryStockCountPlanDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryStockCountPlanDetailCommandHandler : ICommandHandler<UpdateInventoryStockCountPlanDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryStockCountPlanDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryStockCountPlanDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountPlanDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountPlanDetailNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountPlanDetailNotUpdated);
    }
}
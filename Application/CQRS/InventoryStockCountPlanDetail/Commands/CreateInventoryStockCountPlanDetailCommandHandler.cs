using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountPlanDetail.Commands;

public class CreateInventoryStockCountPlanDetailCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateInventoryStockCountPlanDetailCommandHandler : ICommandHandler<CreateInventoryStockCountPlanDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryStockCountPlanDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryStockCountPlanDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.InventoryStockCountPlanDetail.Create(request.IsActive);

        await _unitOfWork.InventoryStockCountPlanDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryStockCountPlanDetailNotInserted);
    }
}
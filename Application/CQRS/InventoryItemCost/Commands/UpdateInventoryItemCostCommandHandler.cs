using Application.Abstractions;

namespace Application.CQRS.InventoryItemCost.Commands;

public class UpdateInventoryItemCostCommand : ICommand<Result>
{
        public int Id { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? CompanyFk { get; set; }
        public decimal? AvgCost { get; set; }
        public decimal? TotalQuantity { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemCostCommandHandler : ICommandHandler<UpdateInventoryItemCostCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemCostCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemCostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemCostRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemCostNotFound);

        entity.Update(request.InventoryItemFk, request.CompanyFk, request.AvgCost, request.TotalQuantity, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemCostNotUpdated);
    }
}
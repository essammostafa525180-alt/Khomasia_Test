using Application.Abstractions;

namespace Application.CQRS.AnnualStockCountItemMerge.Commands;

public class UpdateAnnualStockCountItemMergeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AnnualStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public long? ActiveInventoryItemFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAnnualStockCountItemMergeCommandHandler : ICommandHandler<UpdateAnnualStockCountItemMergeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnnualStockCountItemMergeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAnnualStockCountItemMergeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AnnualStockCountItemMergeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AnnualStockCountItemMergeNotFound);

        entity.Update(request.AnnualStockCountFk, request.InventoryItemFk, request.CurrentQuantity, request.ActiveInventoryItemFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AnnualStockCountItemMergeNotUpdated);
    }
}
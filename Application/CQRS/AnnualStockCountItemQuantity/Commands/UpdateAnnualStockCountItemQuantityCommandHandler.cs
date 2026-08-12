using Application.Abstractions;

namespace Application.CQRS.AnnualStockCountItemQuantity.Commands;

public class UpdateAnnualStockCountItemQuantityCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AnnualStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public string? NewName { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public decimal? StockQuantity { get; set; }
        public Guid? RefId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAnnualStockCountItemQuantityCommandHandler : ICommandHandler<UpdateAnnualStockCountItemQuantityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnnualStockCountItemQuantityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAnnualStockCountItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AnnualStockCountItemQuantityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AnnualStockCountItemQuantityNotFound);

        entity.Update(request.AnnualStockCountFk, request.InventoryItemFk, request.NewName, request.CurrentQuantity, request.StockQuantity, request.RefId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AnnualStockCountItemQuantityNotUpdated);
    }
}
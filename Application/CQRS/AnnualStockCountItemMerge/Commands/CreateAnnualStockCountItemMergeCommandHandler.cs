using Application.Abstractions;

namespace Application.CQRS.AnnualStockCountItemMerge.Commands;

public class CreateAnnualStockCountItemMergeCommand : ICommand<Result<int>>
{
        public int? AnnualStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public long? ActiveInventoryItemFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAnnualStockCountItemMergeCommandHandler : ICommandHandler<CreateAnnualStockCountItemMergeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAnnualStockCountItemMergeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAnnualStockCountItemMergeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.AnnualStockCountItemMerge.Create(request.AnnualStockCountFk, request.InventoryItemFk, request.CurrentQuantity, request.ActiveInventoryItemFk, request.IsActive);

        await _unitOfWork.AnnualStockCountItemMergeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AnnualStockCountItemMergeNotInserted);
    }
}
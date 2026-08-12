using Application.Abstractions;

namespace Application.CQRS.AnnualStockCountItemQuantity.Commands;

public class CreateAnnualStockCountItemQuantityCommand : ICommand<Result<int>>
{
        public int? AnnualStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public string? NewName { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public decimal? StockQuantity { get; set; }
        public Guid? RefId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAnnualStockCountItemQuantityCommandHandler : ICommandHandler<CreateAnnualStockCountItemQuantityCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAnnualStockCountItemQuantityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAnnualStockCountItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.AnnualStockCountItemQuantity.Create(request.AnnualStockCountFk, request.InventoryItemFk, request.NewName, request.CurrentQuantity, request.StockQuantity, request.RefId, request.IsActive);

        await _unitOfWork.AnnualStockCountItemQuantityRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AnnualStockCountItemQuantityNotInserted);
    }
}
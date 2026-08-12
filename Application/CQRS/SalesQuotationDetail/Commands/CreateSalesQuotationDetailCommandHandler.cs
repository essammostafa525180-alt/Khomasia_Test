using Application.Abstractions;

namespace Application.CQRS.SalesQuotationDetail.Commands;

public class CreateSalesQuotationDetailCommand : ICommand<Result<int>>
{
        public int? SalesQuotationFk { get; set; }
        public int? RequestForQuotationDetailFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? VendorCostPrice { get; set; }
        public decimal? CostPriceRatio { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? OrderedQuantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSalesQuotationDetailCommandHandler : ICommandHandler<CreateSalesQuotationDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSalesQuotationDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSalesQuotationDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SalesAggregate.SalesQuotationDetail.Create(request.SalesQuotationFk, request.RequestForQuotationDetailFk, request.InventoryItemFk, request.VendorCostPrice, request.CostPriceRatio, request.CostPrice, request.OrderedQuantity, request.TotalPrice, request.IsActive);

        await _unitOfWork.SalesQuotationDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SalesQuotationDetailNotInserted);
    }
}
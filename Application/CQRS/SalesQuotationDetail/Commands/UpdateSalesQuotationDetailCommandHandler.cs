using Application.Abstractions;

namespace Application.CQRS.SalesQuotationDetail.Commands;

public class UpdateSalesQuotationDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateSalesQuotationDetailCommandHandler : ICommandHandler<UpdateSalesQuotationDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSalesQuotationDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSalesQuotationDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SalesQuotationDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SalesQuotationDetailNotFound);

        entity.Update(request.SalesQuotationFk, request.RequestForQuotationDetailFk, request.InventoryItemFk, request.VendorCostPrice, request.CostPriceRatio, request.CostPrice, request.OrderedQuantity, request.TotalPrice, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SalesQuotationDetailNotUpdated);
    }
}
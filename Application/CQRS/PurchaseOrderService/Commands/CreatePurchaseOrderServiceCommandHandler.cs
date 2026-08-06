using Application.Abstractions;

namespace Application.CQRS.PurchaseOrderService.Commands;

public class CreatePurchaseOrderServiceCommand : ICommand<Result<int>>
{
        public int? OrderScreenFk { get; set; }
        public int? PoserviceTypeFk { get; set; }
        public int? VendorOrderTypeFk { get; set; }
        public int? VendorFk { get; set; }
        public int? Prfk { get; set; }
        public string? OrderNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderByUserFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? LocationFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ScopeFk { get; set; }
        public int? VendorOrderStatusFk { get; set; }
        public int? PaymentTermFk { get; set; }
        public string? PaymentTerms { get; set; }
        public bool? IsApproved { get; set; }
        public int? Duration { get; set; }
        public int? CompanyFk { get; set; }
        public int? ContractId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ContractCode { get; set; }
        public decimal? TotalCost { get; set; }
        public string? Description { get; set; }
        public int? InventoryItemBudgetFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePurchaseOrderServiceCommandHandler : ICommandHandler<CreatePurchaseOrderServiceCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePurchaseOrderServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePurchaseOrderServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.PurchaseOrderService.Create(request.OrderScreenFk, request.PoserviceTypeFk, request.VendorOrderTypeFk, request.VendorFk, request.Prfk, request.OrderNo, request.RequestDate, request.OrderDate, request.OrderByUserFk, request.ProjectFk, request.LocationFk, request.ServiceMainCategoryFk, request.ScopeFk, request.VendorOrderStatusFk, request.PaymentTermFk, request.PaymentTerms, request.IsApproved, request.Duration, request.CompanyFk, request.ContractId, request.StartDate, request.EndDate, request.ContractCode, request.TotalCost, request.Description, request.InventoryItemBudgetFk, request.IsActive);

        await _unitOfWork.PurchaseOrderServiceRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PurchaseOrderServiceNotInserted);
    }
}
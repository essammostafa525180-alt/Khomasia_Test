using Application.Abstractions;

namespace Application.CQRS.InventroyItemRequestWithdraw.Commands;

public class UpdateInventroyItemRequestWithdrawCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? ItemTypeFk { get; set; }
        public string? RequestNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public bool? IsApproved { get; set; }
        public int? RequestedByFk { get; set; }
        public string? RequestedBy { get; set; }
        public int? AssignedToUserFk { get; set; }
        public int? ItemRequestStatusFk { get; set; }
        public string? WorkOrderNo { get; set; }
        public int? StoreFk { get; set; }
        public int? SentCount { get; set; }
        public bool? Axsynced { get; set; }
        public int? ProjectFk { get; set; }
        public int? Oufk { get; set; }
        public DateTime? ItemNeededDate { get; set; }
        public int? ScopeFk { get; set; }
        public int? CompanyFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public bool? SiteManagerApproval { get; set; }
        public int? SiteManagerApprovalUserId { get; set; }
        public DateTime? SiteManagerApprovalDateTime { get; set; }
        public int? WarehouseManagerApprovalUserId { get; set; }
        public DateTime? WarehouseManagerApprovalDateTime { get; set; }
        public int? LocationFk { get; set; }
        public int? InventoryItemBudgetFk { get; set; }
        public int? SourceTypeId { get; set; }
        public int? EntityId { get; set; }
        public string? EntityFormula { get; set; }
        public int? ReceivedFk { get; set; }
        public int? VehicleFk { get; set; }
        public int? LineFk { get; set; }
        public string? SourceEntity { get; set; }
        public int? SourceId { get; set; }
        public int? SectorFk { get; set; }
        public int? CostCenterFk { get; set; }
        public int? CustomerFk { get; set; }
        public int? FactoryFk { get; set; }
        public int? FactoryLineFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventroyItemRequestWithdrawCommandHandler : ICommandHandler<UpdateInventroyItemRequestWithdrawCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventroyItemRequestWithdrawCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventroyItemRequestWithdrawCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventroyItemRequestWithdrawNotFound);

        entity.Update(request.ItemTypeFk, request.RequestNo, request.RequestDate, request.DescriptionEn, request.DescriptionAr, request.IsApproved, request.RequestedByFk, request.RequestedBy, request.AssignedToUserFk, request.ItemRequestStatusFk, request.WorkOrderNo, request.StoreFk, request.SentCount, request.Axsynced, request.ProjectFk, request.Oufk, request.ItemNeededDate, request.ScopeFk, request.CompanyFk, request.ServiceMainCategoryFk, request.SiteManagerApproval, request.SiteManagerApprovalUserId, request.SiteManagerApprovalDateTime, request.WarehouseManagerApprovalUserId, request.WarehouseManagerApprovalDateTime, request.LocationFk, request.InventoryItemBudgetFk, request.SourceTypeId, request.EntityId, request.EntityFormula, request.ReceivedFk, request.VehicleFk, request.LineFk, request.SourceEntity, request.SourceId, request.SectorFk, request.CostCenterFk, request.CustomerFk, request.FactoryFk, request.FactoryLineFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventroyItemRequestWithdrawNotUpdated);
    }
}
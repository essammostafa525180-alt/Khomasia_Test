using Application.Abstractions;

namespace Application.CQRS.AssetItem.Commands;

public class UpdateAssetItemCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetStatusFk { get; set; }
        public decimal? PurchaseValue { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public int? DepartmentFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? AssetLocationFk { get; set; }
        public int? EmployeeFk { get; set; }
        public DateTime? MoveDate { get; set; }
        public int? AssetWarrantyStatusFk { get; set; }
        public DateOnly? EndWarrantyDate { get; set; }
        public bool IsOperational { get; set; }
        public DateOnly? OperationDate { get; set; }
        public DateOnly? ScrapDate { get; set; }
        public DateOnly? MaintenanceDate { get; set; }
        public decimal? DepreciationRate { get; set; }
        public decimal? DepreciationDuration { get; set; }
        public DateOnly? FirstDepreciationDate { get; set; }
        public string? FixedAssetAccountCode { get; set; }
        public string? DepreciationAccountCode { get; set; }
        public int? InsuranceVendorFk { get; set; }
        public string? InsuranceAccountCode { get; set; }
        public string? PolicyNumber { get; set; }
        public DateOnly? PolicyDate { get; set; }
        public DateOnly? PolicyExpiryDate { get; set; }
        public decimal? PolicyAmount { get; set; }
        public string? ModelName { get; set; }
        public DateOnly? ManufactureDate { get; set; }
        public string? Description { get; set; }
        public byte[]? AssetRowVersion { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetItemCommandHandler : ICommandHandler<UpdateAssetItemCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemNotFound);

        entity.Update(request.AssetStatusFk, request.PurchaseValue, request.PurchaseDate, request.DepartmentFk, request.ProjectFk, request.AssetLocationFk, request.EmployeeFk, request.MoveDate, request.AssetWarrantyStatusFk, request.EndWarrantyDate, request.IsOperational, request.OperationDate, request.ScrapDate, request.MaintenanceDate, request.DepreciationRate, request.DepreciationDuration, request.FirstDepreciationDate, request.FixedAssetAccountCode, request.DepreciationAccountCode, request.InsuranceVendorFk, request.InsuranceAccountCode, request.PolicyNumber, request.PolicyDate, request.PolicyExpiryDate, request.PolicyAmount, request.ModelName, request.ManufactureDate, request.Description, request.AssetRowVersion, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemNotUpdated);
    }
}
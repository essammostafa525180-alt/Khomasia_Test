using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityDetail.Commands;

public class UpdateVendorOrderQualityDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderQualityFk { get; set; }
        public int? VendorOrderDetailFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public decimal? LandedCost { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderQualityDetailCommandHandler : ICommandHandler<UpdateVendorOrderQualityDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderQualityDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderQualityDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderQualityDetailNotFound);

        entity.Update(request.VendorOrderQualityFk, request.VendorOrderDetailFk, request.InventoryItemFk, request.ReceivedQuantity, request.LandedCost, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderQualityDetailNotUpdated);
    }
}
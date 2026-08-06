using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetail.Commands;

public class UpdateVendorOrderReceiveDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderReceiveFk { get; set; }
        public int? VendorOrderQualityDetailFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public int? FromSerialize { get; set; }
        public int? ToSerialize { get; set; }
        public string? Notes { get; set; }
        public string? PartNo { get; set; }
        public string? ManufacturerCountry { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderReceiveDetailCommandHandler : ICommandHandler<UpdateVendorOrderReceiveDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderReceiveDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderReceiveDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveDetailNotFound);

        entity.Update(request.VendorOrderReceiveFk, request.VendorOrderQualityDetailFk, request.InventoryItemFk, request.ReceivedQuantity, request.ReturnedQuantity, request.FromSerialize, request.ToSerialize, request.Notes, request.PartNo, request.ManufacturerCountry, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveDetailNotUpdated);
    }
}
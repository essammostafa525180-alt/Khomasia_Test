using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetail.Commands;

public class CreateVendorOrderReceiveDetailCommand : ICommand<Result<int>>
{
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
internal class CreateVendorOrderReceiveDetailCommandHandler : ICommandHandler<CreateVendorOrderReceiveDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderReceiveDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderReceiveDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderReceiveDetail.Create(request.VendorOrderReceiveFk, request.VendorOrderQualityDetailFk, request.InventoryItemFk, request.ReceivedQuantity, request.ReturnedQuantity, request.FromSerialize, request.ToSerialize, request.Notes, request.PartNo, request.ManufacturerCountry, request.IsActive);

        await _unitOfWork.VendorOrderReceiveDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderReceiveDetailNotInserted);
    }
}
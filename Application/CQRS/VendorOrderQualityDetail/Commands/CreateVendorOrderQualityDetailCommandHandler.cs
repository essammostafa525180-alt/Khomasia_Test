using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityDetail.Commands;

public class CreateVendorOrderQualityDetailCommand : ICommand<Result<int>>
{
        public int? VendorOrderQualityFk { get; set; }
        public int? VendorOrderDetailFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public decimal? LandedCost { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderQualityDetailCommandHandler : ICommandHandler<CreateVendorOrderQualityDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderQualityDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderQualityDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderQualityDetail.Create(request.VendorOrderQualityFk, request.VendorOrderDetailFk, request.InventoryItemFk, request.ReceivedQuantity, request.LandedCost, request.IsActive);

        await _unitOfWork.VendorOrderQualityDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderQualityDetailNotInserted);
    }
}
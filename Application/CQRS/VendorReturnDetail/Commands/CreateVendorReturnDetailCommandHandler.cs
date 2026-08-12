using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetail.Commands;

public class CreateVendorReturnDetailCommand : ICommand<Result<int>>
{
        public int? VendorReturnFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorReturnDetailCommandHandler : ICommandHandler<CreateVendorReturnDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorReturnDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorReturnDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorReturnAggregate.VendorReturnDetail.Create(request.VendorReturnFk, request.InventoryItemFk, request.Quantity, request.ReturnReasonFk, request.IsActive);

        await _unitOfWork.VendorReturnDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorReturnDetailNotInserted);
    }
}
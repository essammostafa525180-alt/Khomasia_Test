using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetail.Commands;

public class UpdateVendorReturnDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorReturnFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorReturnDetailCommandHandler : ICommandHandler<UpdateVendorReturnDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorReturnDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorReturnDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnDetailNotFound);

        entity.Update(request.VendorReturnFk, request.InventoryItemFk, request.Quantity, request.ReturnReasonFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnDetailNotUpdated);
    }
}
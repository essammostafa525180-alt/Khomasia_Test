using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetailBatch.Commands;

public class UpdateVendorReturnDetailBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorReturnDetailFk { get; set; }
        public decimal? Quantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public int? BatchFk { get; set; }
        public int? VendorOrderReceiveDetailBatchFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorReturnDetailBatchCommandHandler : ICommandHandler<UpdateVendorReturnDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorReturnDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorReturnDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnDetailBatchNotFound);

        entity.Update(request.VendorReturnDetailFk, request.Quantity, request.ReturnReasonFk, request.Notes, request.BatchFk, request.VendorOrderReceiveDetailBatchFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnDetailBatchNotUpdated);
    }
}
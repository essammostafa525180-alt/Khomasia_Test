using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetailBatchSerial.Commands;

public class UpdateVendorReturnDetailBatchSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorReturnDetailBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorReturnDetailBatchSerialCommandHandler : ICommandHandler<UpdateVendorReturnDetailBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorReturnDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorReturnDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnDetailBatchSerialNotFound);

        entity.Update(request.VendorReturnDetailBatchFk, request.SerialFk, request.ReturnReasonFk, request.Notes, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnDetailBatchSerialNotUpdated);
    }
}
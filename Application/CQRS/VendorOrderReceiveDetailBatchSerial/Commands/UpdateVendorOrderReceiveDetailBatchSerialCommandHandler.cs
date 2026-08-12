using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetailBatchSerial.Commands;

public class UpdateVendorOrderReceiveDetailBatchSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderReceiveDetailBatchFk { get; set; }
        public string? SerialNumber { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderReceiveDetailBatchSerialCommandHandler : ICommandHandler<UpdateVendorOrderReceiveDetailBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderReceiveDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderReceiveDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveDetailBatchSerialNotFound);

        entity.Update(request.VendorOrderReceiveDetailBatchFk, request.SerialNumber, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveDetailBatchSerialNotUpdated);
    }
}
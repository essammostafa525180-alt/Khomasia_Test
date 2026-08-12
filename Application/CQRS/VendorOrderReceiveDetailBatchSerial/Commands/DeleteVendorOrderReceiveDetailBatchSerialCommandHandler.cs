using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetailBatchSerial.Commands;

public class DeleteVendorOrderReceiveDetailBatchSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderReceiveDetailBatchSerialCommandHandler : ICommandHandler<DeleteVendorOrderReceiveDetailBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderReceiveDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderReceiveDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveDetailBatchSerialNotFound);

        _unitOfWork.VendorOrderReceiveDetailBatchSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveDetailBatchSerialNotDeleted);
    }
}
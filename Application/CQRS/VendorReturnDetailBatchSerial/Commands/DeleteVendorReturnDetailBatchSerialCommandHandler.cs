using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetailBatchSerial.Commands;

public class DeleteVendorReturnDetailBatchSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorReturnDetailBatchSerialCommandHandler : ICommandHandler<DeleteVendorReturnDetailBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorReturnDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorReturnDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnDetailBatchSerialNotFound);

        _unitOfWork.VendorReturnDetailBatchSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnDetailBatchSerialNotDeleted);
    }
}
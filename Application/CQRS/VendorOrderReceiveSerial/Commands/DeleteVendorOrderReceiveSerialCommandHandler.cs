using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveSerial.Commands;

public class DeleteVendorOrderReceiveSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderReceiveSerialCommandHandler : ICommandHandler<DeleteVendorOrderReceiveSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderReceiveSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderReceiveSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveSerialNotFound);

        _unitOfWork.VendorOrderReceiveSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveSerialNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VendorReturnSerial.Commands;

public class DeleteVendorReturnSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorReturnSerialCommandHandler : ICommandHandler<DeleteVendorReturnSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorReturnSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorReturnSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnSerialNotFound);

        _unitOfWork.VendorReturnSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnSerialNotDeleted);
    }
}
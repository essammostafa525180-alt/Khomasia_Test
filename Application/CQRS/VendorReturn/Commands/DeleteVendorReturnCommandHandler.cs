using Application.Abstractions;

namespace Application.CQRS.VendorReturn.Commands;

public class DeleteVendorReturnCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorReturnCommandHandler : ICommandHandler<DeleteVendorReturnCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorReturnCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorReturnCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnNotFound);

        _unitOfWork.VendorReturnRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.Vendor.Commands;

public class DeleteVendorCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorCommandHandler : ICommandHandler<DeleteVendorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorNotFound);

        _unitOfWork.VendorRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorNotDeleted);
    }
}
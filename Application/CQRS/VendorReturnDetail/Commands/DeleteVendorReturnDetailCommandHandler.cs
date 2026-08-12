using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetail.Commands;

public class DeleteVendorReturnDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorReturnDetailCommandHandler : ICommandHandler<DeleteVendorReturnDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorReturnDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorReturnDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnDetailNotFound);

        _unitOfWork.VendorReturnDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnDetailNotDeleted);
    }
}
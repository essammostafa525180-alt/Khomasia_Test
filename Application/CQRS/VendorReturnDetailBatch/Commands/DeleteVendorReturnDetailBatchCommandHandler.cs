using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetailBatch.Commands;

public class DeleteVendorReturnDetailBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorReturnDetailBatchCommandHandler : ICommandHandler<DeleteVendorReturnDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorReturnDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorReturnDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnDetailBatchNotFound);

        _unitOfWork.VendorReturnDetailBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnDetailBatchNotDeleted);
    }
}
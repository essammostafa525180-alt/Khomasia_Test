using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetailBatch.Commands;

public class DeleteVendorOrderReceiveDetailBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderReceiveDetailBatchCommandHandler : ICommandHandler<DeleteVendorOrderReceiveDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderReceiveDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderReceiveDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveDetailBatchNotFound);

        _unitOfWork.VendorOrderReceiveDetailBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveDetailBatchNotDeleted);
    }
}
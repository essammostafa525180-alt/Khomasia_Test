using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityDetailBatch.Commands;

public class DeleteVendorOrderQualityDetailBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderQualityDetailBatchCommandHandler : ICommandHandler<DeleteVendorOrderQualityDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderQualityDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderQualityDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderQualityDetailBatchNotFound);

        _unitOfWork.VendorOrderQualityDetailBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderQualityDetailBatchNotDeleted);
    }
}
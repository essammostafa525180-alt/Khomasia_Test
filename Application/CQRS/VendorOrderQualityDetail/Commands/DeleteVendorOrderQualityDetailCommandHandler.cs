using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityDetail.Commands;

public class DeleteVendorOrderQualityDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderQualityDetailCommandHandler : ICommandHandler<DeleteVendorOrderQualityDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderQualityDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderQualityDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderQualityDetailNotFound);

        _unitOfWork.VendorOrderQualityDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderQualityDetailNotDeleted);
    }
}
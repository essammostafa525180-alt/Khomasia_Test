using Application.Abstractions;

namespace Application.CQRS.VendorOrderQuality.Commands;

public class DeleteVendorOrderQualityCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderQualityCommandHandler : ICommandHandler<DeleteVendorOrderQualityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderQualityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderQualityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderQualityNotFound);

        _unitOfWork.VendorOrderQualityRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderQualityNotDeleted);
    }
}
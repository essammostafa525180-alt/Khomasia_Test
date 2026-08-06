using Application.Abstractions;

namespace Application.CQRS.VendorOrderQuality.Commands;

public class UpdateVendorOrderQualityCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderQualityCommandHandler : ICommandHandler<UpdateVendorOrderQualityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderQualityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderQualityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderQualityNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderQualityNotUpdated);
    }
}
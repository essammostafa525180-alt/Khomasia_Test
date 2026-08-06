using Application.Abstractions;

namespace Application.CQRS.VendorSpecialization.Commands;

public class DeleteVendorSpecializationCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorSpecializationCommandHandler : ICommandHandler<DeleteVendorSpecializationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorSpecializationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorSpecializationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorSpecializationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorSpecializationNotFound);

        _unitOfWork.VendorSpecializationRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorSpecializationNotDeleted);
    }
}
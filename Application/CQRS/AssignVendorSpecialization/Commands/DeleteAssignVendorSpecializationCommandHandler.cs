using Application.Abstractions;

namespace Application.CQRS.AssignVendorSpecialization.Commands;

public class DeleteAssignVendorSpecializationCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssignVendorSpecializationCommandHandler : ICommandHandler<DeleteAssignVendorSpecializationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssignVendorSpecializationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssignVendorSpecializationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignVendorSpecializationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignVendorSpecializationNotFound);

        _unitOfWork.AssignVendorSpecializationRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignVendorSpecializationNotDeleted);
    }
}
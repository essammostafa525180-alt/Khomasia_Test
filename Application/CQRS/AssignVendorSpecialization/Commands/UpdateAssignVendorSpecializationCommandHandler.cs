using Application.Abstractions;

namespace Application.CQRS.AssignVendorSpecialization.Commands;

public class UpdateAssignVendorSpecializationCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorFk { get; set; }
        public int? VendorSpecializationFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssignVendorSpecializationCommandHandler : ICommandHandler<UpdateAssignVendorSpecializationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssignVendorSpecializationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssignVendorSpecializationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignVendorSpecializationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignVendorSpecializationNotFound);

        entity.Update(request.VendorFk, request.VendorSpecializationFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignVendorSpecializationNotUpdated);
    }
}
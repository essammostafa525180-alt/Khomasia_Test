using Application.Abstractions;

namespace Application.CQRS.AssignVendorSpecialization.Commands;

public class CreateAssignVendorSpecializationCommand : ICommand<Result<int>>
{
        public int? VendorFk { get; set; }
        public int? VendorSpecializationFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssignVendorSpecializationCommandHandler : ICommandHandler<CreateAssignVendorSpecializationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssignVendorSpecializationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssignVendorSpecializationCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorAggregate.AssignVendorSpecialization.Create(request.VendorFk, request.VendorSpecializationFk, request.IsActive);

        await _unitOfWork.AssignVendorSpecializationRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssignVendorSpecializationNotInserted);
    }
}
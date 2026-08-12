using Application.Abstractions;

namespace Application.CQRS.VendorSpecialization.Commands;

public class CreateVendorSpecializationCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorSpecializationCommandHandler : ICommandHandler<CreateVendorSpecializationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorSpecializationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorSpecializationCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VendorSpecialization.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VendorSpecializationRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorSpecializationNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InsuranceVendor.Commands;

public class CreateInsuranceVendorCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInsuranceVendorCommandHandler : ICommandHandler<CreateInsuranceVendorCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInsuranceVendorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInsuranceVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.InsuranceVendor.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.InsuranceVendorRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InsuranceVendorNotInserted);
    }
}
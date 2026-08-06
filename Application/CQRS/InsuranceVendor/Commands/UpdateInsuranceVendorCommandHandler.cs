using Application.Abstractions;

namespace Application.CQRS.InsuranceVendor.Commands;

public class UpdateInsuranceVendorCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInsuranceVendorCommandHandler : ICommandHandler<UpdateInsuranceVendorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInsuranceVendorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInsuranceVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InsuranceVendorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InsuranceVendorNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InsuranceVendorNotUpdated);
    }
}
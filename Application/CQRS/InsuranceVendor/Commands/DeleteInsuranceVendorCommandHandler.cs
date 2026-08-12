using Application.Abstractions;

namespace Application.CQRS.InsuranceVendor.Commands;

public class DeleteInsuranceVendorCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInsuranceVendorCommandHandler : ICommandHandler<DeleteInsuranceVendorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInsuranceVendorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInsuranceVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InsuranceVendorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InsuranceVendorNotFound);

        _unitOfWork.InsuranceVendorRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InsuranceVendorNotDeleted);
    }
}
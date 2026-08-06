using Application.Abstractions;

namespace Application.CQRS.PoserviceRecomendedResource.Commands;

public class UpdatePoserviceRecomendedResourceCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int PoserviceFk { get; set; }
        public int? ContractFk { get; set; }
        public int? EmployeeJobFk { get; set; }
        public int? VendorFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePoserviceRecomendedResourceCommandHandler : ICommandHandler<UpdatePoserviceRecomendedResourceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePoserviceRecomendedResourceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePoserviceRecomendedResourceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceRecomendedResourceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceRecomendedResourceNotFound);

        entity.Update(request.PoserviceFk, request.ContractFk, request.EmployeeJobFk, request.VendorFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceRecomendedResourceNotUpdated);
    }
}
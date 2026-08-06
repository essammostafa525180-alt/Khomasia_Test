using Application.Abstractions;

namespace Application.CQRS.PoserviceRecomendedResource.Commands;

public class CreatePoserviceRecomendedResourceCommand : ICommand<Result<int>>
{
        public int PoserviceFk { get; set; }
        public int? ContractFk { get; set; }
        public int? EmployeeJobFk { get; set; }
        public int? VendorFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePoserviceRecomendedResourceCommandHandler : ICommandHandler<CreatePoserviceRecomendedResourceCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePoserviceRecomendedResourceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePoserviceRecomendedResourceCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.PoserviceRecomendedResource.Create(request.PoserviceFk, request.ContractFk, request.EmployeeJobFk, request.VendorFk, request.IsActive);

        await _unitOfWork.PoserviceRecomendedResourceRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PoserviceRecomendedResourceNotInserted);
    }
}
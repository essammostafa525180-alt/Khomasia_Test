using Application.Abstractions;

namespace Application.CQRS.Service.Commands;

public class CreateServiceCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ServiceTypeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ServiceCategoryFk { get; set; }
        public int? ServiceSubCategoryFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateServiceCommandHandler : ICommandHandler<CreateServiceCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.Service.Create(request.Code, request.Name, request.NameAr, request.ServiceTypeFk, request.ServiceMainCategoryFk, request.ServiceCategoryFk, request.ServiceSubCategoryFk, request.IsActive);

        await _unitOfWork.ServiceRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ServiceNotInserted);
    }
}
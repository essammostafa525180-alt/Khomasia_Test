using Application.Abstractions;

namespace Application.CQRS.ServiceSubCategory.Commands;

public class CreateServiceSubCategoryCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ServiceTypeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ServiceCategoryFk { get; set; }
        public int? CompanyFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateServiceSubCategoryCommandHandler : ICommandHandler<CreateServiceSubCategoryCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceSubCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateServiceSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ServiceSubCategory.Create(request.Code, request.Name, request.NameAr, request.ServiceTypeFk, request.ServiceMainCategoryFk, request.ServiceCategoryFk, request.CompanyFk, request.IsActive);

        await _unitOfWork.ServiceSubCategoryRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ServiceSubCategoryNotInserted);
    }
}
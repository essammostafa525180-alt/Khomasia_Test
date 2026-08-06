using Application.Abstractions;

namespace Application.CQRS.ServiceCategory.Commands;

public class CreateServiceCategoryCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ServiceTypeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? CompanyFk { get; set; }
        public bool? IsFelKhedma { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateServiceCategoryCommandHandler : ICommandHandler<CreateServiceCategoryCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ServiceCategory.Create(request.Code, request.Name, request.NameAr, request.ServiceTypeFk, request.ServiceMainCategoryFk, request.CompanyFk, request.IsFelKhedma, request.IsActive);

        await _unitOfWork.ServiceCategoryRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ServiceCategoryNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ServiceSubCategory.Commands;

public class UpdateServiceSubCategoryCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ServiceTypeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ServiceCategoryFk { get; set; }
        public int? CompanyFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateServiceSubCategoryCommandHandler : ICommandHandler<UpdateServiceSubCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateServiceSubCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateServiceSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceSubCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ServiceSubCategoryNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.ServiceTypeFk, request.ServiceMainCategoryFk, request.ServiceCategoryFk, request.CompanyFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ServiceSubCategoryNotUpdated);
    }
}
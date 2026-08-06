using Application.Abstractions;

namespace Application.CQRS.MaterialSubCategory.Commands;

public class UpdateMaterialSubCategoryCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? MaterialGroupFk { get; set; }
        public int? MaterialCategoryFk { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateMaterialSubCategoryCommandHandler : ICommandHandler<UpdateMaterialSubCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMaterialSubCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateMaterialSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialSubCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.MaterialSubCategoryNotFound);

        entity.Update(request.MaterialGroupFk, request.MaterialCategoryFk, request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.MaterialSubCategoryNotUpdated);
    }
}
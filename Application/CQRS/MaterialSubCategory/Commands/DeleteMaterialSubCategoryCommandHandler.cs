using Application.Abstractions;

namespace Application.CQRS.MaterialSubCategory.Commands;

public class DeleteMaterialSubCategoryCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteMaterialSubCategoryCommandHandler : ICommandHandler<DeleteMaterialSubCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMaterialSubCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteMaterialSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialSubCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.MaterialSubCategoryNotFound);

        _unitOfWork.MaterialSubCategoryRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.MaterialSubCategoryNotDeleted);
    }
}
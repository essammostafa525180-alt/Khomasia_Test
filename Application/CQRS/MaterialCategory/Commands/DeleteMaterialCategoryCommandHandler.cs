using Application.Abstractions;

namespace Application.CQRS.MaterialCategory.Commands;

public class DeleteMaterialCategoryCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteMaterialCategoryCommandHandler : ICommandHandler<DeleteMaterialCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMaterialCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteMaterialCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.MaterialCategoryNotFound);

        _unitOfWork.MaterialCategoryRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.MaterialCategoryNotDeleted);
    }
}
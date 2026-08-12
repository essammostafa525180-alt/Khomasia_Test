using Application.Abstractions;

namespace Application.CQRS.ServiceSubCategory.Commands;

public class DeleteServiceSubCategoryCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteServiceSubCategoryCommandHandler : ICommandHandler<DeleteServiceSubCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceSubCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteServiceSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceSubCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ServiceSubCategoryNotFound);

        _unitOfWork.ServiceSubCategoryRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ServiceSubCategoryNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ServiceMainCategory.Commands;

public class DeleteServiceMainCategoryCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteServiceMainCategoryCommandHandler : ICommandHandler<DeleteServiceMainCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceMainCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteServiceMainCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceMainCategoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ServiceMainCategoryNotFound);

        _unitOfWork.ServiceMainCategoryRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ServiceMainCategoryNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssetsGroup.Commands;

public class DeleteAssetsGroupCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetsGroupCommandHandler : ICommandHandler<DeleteAssetsGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetsGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetsGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetsGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetsGroupNotFound);

        _unitOfWork.AssetsGroupRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetsGroupNotDeleted);
    }
}
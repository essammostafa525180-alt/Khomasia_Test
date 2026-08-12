using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanStatus.Commands;

public class DeleteAssetCountPlanStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountPlanStatusCommandHandler : ICommandHandler<DeleteAssetCountPlanStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountPlanStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountPlanStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountPlanStatusNotFound);

        _unitOfWork.AssetCountPlanStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountPlanStatusNotDeleted);
    }
}
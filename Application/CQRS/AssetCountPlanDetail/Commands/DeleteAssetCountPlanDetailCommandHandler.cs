using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanDetail.Commands;

public class DeleteAssetCountPlanDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountPlanDetailCommandHandler : ICommandHandler<DeleteAssetCountPlanDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountPlanDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountPlanDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountPlanDetailNotFound);

        _unitOfWork.AssetCountPlanDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountPlanDetailNotDeleted);
    }
}
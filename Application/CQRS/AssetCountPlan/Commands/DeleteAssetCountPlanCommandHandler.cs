using Application.Abstractions;

namespace Application.CQRS.AssetCountPlan.Commands;

public class DeleteAssetCountPlanCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountPlanCommandHandler : ICommandHandler<DeleteAssetCountPlanCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountPlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountPlanNotFound);

        _unitOfWork.AssetCountPlanRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountPlanNotDeleted);
    }
}
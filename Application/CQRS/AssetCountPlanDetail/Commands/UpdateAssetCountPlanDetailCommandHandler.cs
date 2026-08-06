using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanDetail.Commands;

public class UpdateAssetCountPlanDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetCountPlanFk { get; set; }
        public int? ZoneFk { get; set; }
        public int? AssignedToUserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCountPlanDetailCommandHandler : ICommandHandler<UpdateAssetCountPlanDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountPlanDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountPlanDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountPlanDetailNotFound);

        entity.Update(request.AssetCountPlanFk, request.ZoneFk, request.AssignedToUserFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountPlanDetailNotUpdated);
    }
}
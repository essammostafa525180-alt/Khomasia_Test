using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanDetail.Commands;

public class CreateAssetCountPlanDetailCommand : ICommand<Result<int>>
{
        public int? AssetCountPlanFk { get; set; }
        public int? ZoneFk { get; set; }
        public int? AssignedToUserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountPlanDetailCommandHandler : ICommandHandler<CreateAssetCountPlanDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountPlanDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountPlanDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetCountPlanDetail.Create(request.AssetCountPlanFk, request.ZoneFk, request.AssignedToUserFk, request.IsActive);

        await _unitOfWork.AssetCountPlanDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountPlanDetailNotInserted);
    }
}
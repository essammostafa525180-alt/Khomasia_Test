using Application.Abstractions;

namespace Application.CQRS.AssetCountPlan.Commands;

public class CreateAssetCountPlanCommand : ICommand<Result<int>>
{
        public string? PlanNumber { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? AssetCountPlanTypeFk { get; set; }
        public int? AssetCountPlanStatusFk { get; set; }
        public DateTime? PlaneDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public int? AssignedToUserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetCountPlanCommandHandler : ICommandHandler<CreateAssetCountPlanCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCountPlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCountPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetCountPlan.Create(request.PlanNumber, request.Name, request.NameAr, request.AssetCountPlanTypeFk, request.AssetCountPlanStatusFk, request.PlaneDate, request.ExecutionDate, request.AssignedToUserFk, request.IsActive);

        await _unitOfWork.AssetCountPlanRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetCountPlanNotInserted);
    }
}
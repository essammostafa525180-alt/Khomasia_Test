using Application.Abstractions;

namespace Application.CQRS.AssetCountPlan.Commands;

public class UpdateAssetCountPlanCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateAssetCountPlanCommandHandler : ICommandHandler<UpdateAssetCountPlanCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountPlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountPlanNotFound);

        entity.Update(request.PlanNumber, request.Name, request.NameAr, request.AssetCountPlanTypeFk, request.AssetCountPlanStatusFk, request.PlaneDate, request.ExecutionDate, request.AssignedToUserFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountPlanNotUpdated);
    }
}
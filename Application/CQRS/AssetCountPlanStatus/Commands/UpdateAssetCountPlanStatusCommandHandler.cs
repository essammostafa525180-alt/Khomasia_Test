using Application.Abstractions;

namespace Application.CQRS.AssetCountPlanStatus.Commands;

public class UpdateAssetCountPlanStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetCountPlanStatusCommandHandler : ICommandHandler<UpdateAssetCountPlanStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetCountPlanStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetCountPlanStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountPlanStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountPlanStatusNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.AssetItemMaintenance.Commands;

public class UpdateAssetItemMaintenanceCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetItemFk { get; set; }
        public string? Code { get; set; }
        public int? AssetItemMoveFk { get; set; }
        public int? AssetMaintenanceStatusFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetItemMaintenanceCommandHandler : ICommandHandler<UpdateAssetItemMaintenanceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetItemMaintenanceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetItemMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemMaintenanceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemMaintenanceNotFound);

        entity.Update(request.AssetItemFk, request.Code, request.AssetItemMoveFk, request.AssetMaintenanceStatusFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemMaintenanceNotUpdated);
    }
}
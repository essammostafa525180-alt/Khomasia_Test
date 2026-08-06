using Application.Abstractions;

namespace Application.CQRS.AssetItemMaintenance.Commands;

public class DeleteAssetItemMaintenanceCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetItemMaintenanceCommandHandler : ICommandHandler<DeleteAssetItemMaintenanceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetItemMaintenanceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetItemMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemMaintenanceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemMaintenanceNotFound);

        _unitOfWork.AssetItemMaintenanceRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemMaintenanceNotDeleted);
    }
}
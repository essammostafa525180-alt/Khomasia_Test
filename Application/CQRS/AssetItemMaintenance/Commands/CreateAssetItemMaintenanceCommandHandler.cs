using Application.Abstractions;

namespace Application.CQRS.AssetItemMaintenance.Commands;

public class CreateAssetItemMaintenanceCommand : ICommand<Result<int>>
{
        public int? AssetItemFk { get; set; }
        public string? Code { get; set; }
        public int? AssetItemMoveFk { get; set; }
        public int? AssetMaintenanceStatusFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetItemMaintenanceCommandHandler : ICommandHandler<CreateAssetItemMaintenanceCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetItemMaintenanceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetItemMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetItemMaintenance.Create(request.AssetItemFk, request.Code, request.AssetItemMoveFk, request.AssetMaintenanceStatusFk, request.IsActive);

        await _unitOfWork.AssetItemMaintenanceRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetItemMaintenanceNotInserted);
    }
}
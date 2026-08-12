using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetItemMaintenance.Queries;

public class GetAssetItemMaintenanceByIdQuery : IQuery<Result<AssetItemMaintenanceDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetItemMaintenanceByIdQueryHandler : IQueryHandler<GetAssetItemMaintenanceByIdQuery, Result<AssetItemMaintenanceDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetItemMaintenanceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetItemMaintenanceDetailsResponse>> Handle(GetAssetItemMaintenanceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemMaintenanceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetItemMaintenanceDetailsResponse>.Failure(Errors.AssetItemMaintenanceNotFound);

        var response = entity.Adapt<AssetItemMaintenanceDetailsResponse>();

        return Result<AssetItemMaintenanceDetailsResponse>.Success(response);
    }
}
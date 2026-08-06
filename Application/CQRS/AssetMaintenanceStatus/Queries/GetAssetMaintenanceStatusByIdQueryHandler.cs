using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetMaintenanceStatus.Queries;

public class GetAssetMaintenanceStatusByIdQuery : IQuery<Result<AssetMaintenanceStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetMaintenanceStatusByIdQueryHandler : IQueryHandler<GetAssetMaintenanceStatusByIdQuery, Result<AssetMaintenanceStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetMaintenanceStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetMaintenanceStatusDetailsResponse>> Handle(GetAssetMaintenanceStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetMaintenanceStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetMaintenanceStatusDetailsResponse>.Failure(Errors.AssetMaintenanceStatusNotFound);

        var response = entity.Adapt<AssetMaintenanceStatusDetailsResponse>();

        return Result<AssetMaintenanceStatusDetailsResponse>.Success(response);
    }
}
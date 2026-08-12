using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemAsset.Queries;

public class GetInventoryItemAssetByIdQuery : IQuery<Result<InventoryItemAssetDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemAssetByIdQueryHandler : IQueryHandler<GetInventoryItemAssetByIdQuery, Result<InventoryItemAssetDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemAssetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemAssetDetailsResponse>> Handle(GetInventoryItemAssetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemAssetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemAssetDetailsResponse>.Failure(Errors.InventoryItemAssetNotFound);

        var response = entity.Adapt<InventoryItemAssetDetailsResponse>();

        return Result<InventoryItemAssetDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetItemMove.Queries;

public class GetAssetItemMoveByIdQuery : IQuery<Result<AssetItemMoveDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetItemMoveByIdQueryHandler : IQueryHandler<GetAssetItemMoveByIdQuery, Result<AssetItemMoveDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetItemMoveByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetItemMoveDetailsResponse>> Handle(GetAssetItemMoveByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemMoveRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetItemMoveDetailsResponse>.Failure(Errors.AssetItemMoveNotFound);

        var response = entity.Adapt<AssetItemMoveDetailsResponse>();

        return Result<AssetItemMoveDetailsResponse>.Success(response);
    }
}
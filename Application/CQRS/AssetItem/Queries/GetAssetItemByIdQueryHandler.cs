using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetItem.Queries;

public class GetAssetItemByIdQuery : IQuery<Result<AssetItemDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetItemByIdQueryHandler : IQueryHandler<GetAssetItemByIdQuery, Result<AssetItemDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetItemByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetItemDetailsResponse>> Handle(GetAssetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetItemDetailsResponse>.Failure(Errors.AssetItemNotFound);

        var response = entity.Adapt<AssetItemDetailsResponse>();

        return Result<AssetItemDetailsResponse>.Success(response);
    }
}
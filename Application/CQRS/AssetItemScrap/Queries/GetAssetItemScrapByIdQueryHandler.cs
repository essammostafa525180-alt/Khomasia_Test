using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetItemScrap.Queries;

public class GetAssetItemScrapByIdQuery : IQuery<Result<AssetItemScrapDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetItemScrapByIdQueryHandler : IQueryHandler<GetAssetItemScrapByIdQuery, Result<AssetItemScrapDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetItemScrapByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetItemScrapDetailsResponse>> Handle(GetAssetItemScrapByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemScrapRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetItemScrapDetailsResponse>.Failure(Errors.AssetItemScrapNotFound);

        var response = entity.Adapt<AssetItemScrapDetailsResponse>();

        return Result<AssetItemScrapDetailsResponse>.Success(response);
    }
}
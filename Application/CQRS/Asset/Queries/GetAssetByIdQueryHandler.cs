using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Asset.Queries;

public class GetAssetByIdQuery : IQuery<Result<AssetDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetByIdQueryHandler : IQueryHandler<GetAssetByIdQuery, Result<AssetDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetDetailsResponse>> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetDetailsResponse>.Failure(Errors.AssetNotFound);

        var response = entity.Adapt<AssetDetailsResponse>();

        return Result<AssetDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetScrapStatus.Queries;

public class GetAssetScrapStatusByIdQuery : IQuery<Result<AssetScrapStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetScrapStatusByIdQueryHandler : IQueryHandler<GetAssetScrapStatusByIdQuery, Result<AssetScrapStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetScrapStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetScrapStatusDetailsResponse>> Handle(GetAssetScrapStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetScrapStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetScrapStatusDetailsResponse>.Failure(Errors.AssetScrapStatusNotFound);

        var response = entity.Adapt<AssetScrapStatusDetailsResponse>();

        return Result<AssetScrapStatusDetailsResponse>.Success(response);
    }
}
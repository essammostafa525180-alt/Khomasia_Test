using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCount.Queries;

public class GetAssetCountByIdQuery : IQuery<Result<AssetCountDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountByIdQueryHandler : IQueryHandler<GetAssetCountByIdQuery, Result<AssetCountDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountDetailsResponse>> Handle(GetAssetCountByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountDetailsResponse>.Failure(Errors.AssetCountNotFound);

        var response = entity.Adapt<AssetCountDetailsResponse>();

        return Result<AssetCountDetailsResponse>.Success(response);
    }
}
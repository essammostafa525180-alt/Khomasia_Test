using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCompline.Queries;

public class GetAssetComplineByIdQuery : IQuery<Result<AssetComplineDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetComplineByIdQueryHandler : IQueryHandler<GetAssetComplineByIdQuery, Result<AssetComplineDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetComplineByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetComplineDetailsResponse>> Handle(GetAssetComplineByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetComplineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetComplineDetailsResponse>.Failure(Errors.AssetComplineNotFound);

        var response = entity.Adapt<AssetComplineDetailsResponse>();

        return Result<AssetComplineDetailsResponse>.Success(response);
    }
}
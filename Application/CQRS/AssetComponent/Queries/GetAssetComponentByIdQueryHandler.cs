using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetComponent.Queries;

public class GetAssetComponentByIdQuery : IQuery<Result<AssetComponentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetComponentByIdQueryHandler : IQueryHandler<GetAssetComponentByIdQuery, Result<AssetComponentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetComponentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetComponentDetailsResponse>> Handle(GetAssetComponentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetComponentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetComponentDetailsResponse>.Failure(Errors.AssetComponentNotFound);

        var response = entity.Adapt<AssetComponentDetailsResponse>();

        return Result<AssetComponentDetailsResponse>.Success(response);
    }
}
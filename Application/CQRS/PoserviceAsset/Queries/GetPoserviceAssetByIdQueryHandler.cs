using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PoserviceAsset.Queries;

public class GetPoserviceAssetByIdQuery : IQuery<Result<PoserviceAssetDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPoserviceAssetByIdQueryHandler : IQueryHandler<GetPoserviceAssetByIdQuery, Result<PoserviceAssetDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPoserviceAssetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PoserviceAssetDetailsResponse>> Handle(GetPoserviceAssetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceAssetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PoserviceAssetDetailsResponse>.Failure(Errors.PoserviceAssetNotFound);

        var response = entity.Adapt<PoserviceAssetDetailsResponse>();

        return Result<PoserviceAssetDetailsResponse>.Success(response);
    }
}
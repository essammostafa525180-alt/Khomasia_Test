using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCommissioning.Queries;

public class GetAssetCommissioningByIdQuery : IQuery<Result<AssetCommissioningDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCommissioningByIdQueryHandler : IQueryHandler<GetAssetCommissioningByIdQuery, Result<AssetCommissioningDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCommissioningByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCommissioningDetailsResponse>> Handle(GetAssetCommissioningByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCommissioningRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCommissioningDetailsResponse>.Failure(Errors.AssetCommissioningNotFound);

        var response = entity.Adapt<AssetCommissioningDetailsResponse>();

        return Result<AssetCommissioningDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCountPlanDetail.Queries;

public class GetAssetCountPlanDetailByIdQuery : IQuery<Result<AssetCountPlanDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountPlanDetailByIdQueryHandler : IQueryHandler<GetAssetCountPlanDetailByIdQuery, Result<AssetCountPlanDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountPlanDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountPlanDetailDetailsResponse>> Handle(GetAssetCountPlanDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountPlanDetailDetailsResponse>.Failure(Errors.AssetCountPlanDetailNotFound);

        var response = entity.Adapt<AssetCountPlanDetailDetailsResponse>();

        return Result<AssetCountPlanDetailDetailsResponse>.Success(response);
    }
}
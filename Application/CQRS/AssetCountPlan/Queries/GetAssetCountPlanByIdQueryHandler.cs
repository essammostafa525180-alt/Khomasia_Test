using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCountPlan.Queries;

public class GetAssetCountPlanByIdQuery : IQuery<Result<AssetCountPlanDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountPlanByIdQueryHandler : IQueryHandler<GetAssetCountPlanByIdQuery, Result<AssetCountPlanDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountPlanByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountPlanDetailsResponse>> Handle(GetAssetCountPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountPlanDetailsResponse>.Failure(Errors.AssetCountPlanNotFound);

        var response = entity.Adapt<AssetCountPlanDetailsResponse>();

        return Result<AssetCountPlanDetailsResponse>.Success(response);
    }
}
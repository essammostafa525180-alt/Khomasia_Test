using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCountPlanType.Queries;

public class GetAssetCountPlanTypeByIdQuery : IQuery<Result<AssetCountPlanTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountPlanTypeByIdQueryHandler : IQueryHandler<GetAssetCountPlanTypeByIdQuery, Result<AssetCountPlanTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountPlanTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountPlanTypeDetailsResponse>> Handle(GetAssetCountPlanTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountPlanTypeDetailsResponse>.Failure(Errors.AssetCountPlanTypeNotFound);

        var response = entity.Adapt<AssetCountPlanTypeDetailsResponse>();

        return Result<AssetCountPlanTypeDetailsResponse>.Success(response);
    }
}
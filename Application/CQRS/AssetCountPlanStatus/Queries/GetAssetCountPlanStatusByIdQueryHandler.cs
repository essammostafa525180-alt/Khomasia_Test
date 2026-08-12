using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCountPlanStatus.Queries;

public class GetAssetCountPlanStatusByIdQuery : IQuery<Result<AssetCountPlanStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountPlanStatusByIdQueryHandler : IQueryHandler<GetAssetCountPlanStatusByIdQuery, Result<AssetCountPlanStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountPlanStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountPlanStatusDetailsResponse>> Handle(GetAssetCountPlanStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountPlanStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountPlanStatusDetailsResponse>.Failure(Errors.AssetCountPlanStatusNotFound);

        var response = entity.Adapt<AssetCountPlanStatusDetailsResponse>();

        return Result<AssetCountPlanStatusDetailsResponse>.Success(response);
    }
}
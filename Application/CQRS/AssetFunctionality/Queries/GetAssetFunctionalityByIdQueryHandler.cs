using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetFunctionality.Queries;

public class GetAssetFunctionalityByIdQuery : IQuery<Result<AssetFunctionalityDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetFunctionalityByIdQueryHandler : IQueryHandler<GetAssetFunctionalityByIdQuery, Result<AssetFunctionalityDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetFunctionalityByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetFunctionalityDetailsResponse>> Handle(GetAssetFunctionalityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetFunctionalityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetFunctionalityDetailsResponse>.Failure(Errors.AssetFunctionalityNotFound);

        var response = entity.Adapt<AssetFunctionalityDetailsResponse>();

        return Result<AssetFunctionalityDetailsResponse>.Success(response);
    }
}
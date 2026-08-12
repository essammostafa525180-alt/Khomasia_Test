using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetMoveType.Queries;

public class GetAssetMoveTypeByIdQuery : IQuery<Result<AssetMoveTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetMoveTypeByIdQueryHandler : IQueryHandler<GetAssetMoveTypeByIdQuery, Result<AssetMoveTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetMoveTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetMoveTypeDetailsResponse>> Handle(GetAssetMoveTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetMoveTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetMoveTypeDetailsResponse>.Failure(Errors.AssetMoveTypeNotFound);

        var response = entity.Adapt<AssetMoveTypeDetailsResponse>();

        return Result<AssetMoveTypeDetailsResponse>.Success(response);
    }
}
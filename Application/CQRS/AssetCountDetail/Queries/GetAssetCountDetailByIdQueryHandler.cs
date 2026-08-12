using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCountDetail.Queries;

public class GetAssetCountDetailByIdQuery : IQuery<Result<AssetCountDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountDetailByIdQueryHandler : IQueryHandler<GetAssetCountDetailByIdQuery, Result<AssetCountDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountDetailDetailsResponse>> Handle(GetAssetCountDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountDetailDetailsResponse>.Failure(Errors.AssetCountDetailNotFound);

        var response = entity.Adapt<AssetCountDetailDetailsResponse>();

        return Result<AssetCountDetailDetailsResponse>.Success(response);
    }
}
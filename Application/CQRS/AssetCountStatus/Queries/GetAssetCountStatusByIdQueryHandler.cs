using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetCountStatus.Queries;

public class GetAssetCountStatusByIdQuery : IQuery<Result<AssetCountStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetCountStatusByIdQueryHandler : IQueryHandler<GetAssetCountStatusByIdQuery, Result<AssetCountStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetCountStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetCountStatusDetailsResponse>> Handle(GetAssetCountStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetCountStatusDetailsResponse>.Failure(Errors.AssetCountStatusNotFound);

        var response = entity.Adapt<AssetCountStatusDetailsResponse>();

        return Result<AssetCountStatusDetailsResponse>.Success(response);
    }
}
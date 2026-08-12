using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetDisposed.Queries;

public class GetAssetDisposedByIdQuery : IQuery<Result<AssetDisposedDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetDisposedByIdQueryHandler : IQueryHandler<GetAssetDisposedByIdQuery, Result<AssetDisposedDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetDisposedByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetDisposedDetailsResponse>> Handle(GetAssetDisposedByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetDisposedRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetDisposedDetailsResponse>.Failure(Errors.AssetDisposedNotFound);

        var response = entity.Adapt<AssetDisposedDetailsResponse>();

        return Result<AssetDisposedDetailsResponse>.Success(response);
    }
}
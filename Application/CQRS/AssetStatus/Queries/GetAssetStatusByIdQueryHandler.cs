using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetStatus.Queries;

public class GetAssetStatusByIdQuery : IQuery<Result<AssetStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetStatusByIdQueryHandler : IQueryHandler<GetAssetStatusByIdQuery, Result<AssetStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetStatusDetailsResponse>> Handle(GetAssetStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetStatusDetailsResponse>.Failure(Errors.AssetStatusNotFound);

        var response = entity.Adapt<AssetStatusDetailsResponse>();

        return Result<AssetStatusDetailsResponse>.Success(response);
    }
}
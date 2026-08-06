using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetWarrantyStatus.Queries;

public class GetAssetWarrantyStatusByIdQuery : IQuery<Result<AssetWarrantyStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetWarrantyStatusByIdQueryHandler : IQueryHandler<GetAssetWarrantyStatusByIdQuery, Result<AssetWarrantyStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetWarrantyStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetWarrantyStatusDetailsResponse>> Handle(GetAssetWarrantyStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetWarrantyStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetWarrantyStatusDetailsResponse>.Failure(Errors.AssetWarrantyStatusNotFound);

        var response = entity.Adapt<AssetWarrantyStatusDetailsResponse>();

        return Result<AssetWarrantyStatusDetailsResponse>.Success(response);
    }
}
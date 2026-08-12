using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetWarrantyStatus.Queries;

public class GetAllAssetWarrantyStatusQuery
: IQuery<Result<PagingSortingFiltering<AssetWarrantyStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetWarrantyStatusQueryHandler :
    IQueryHandler<GetAllAssetWarrantyStatusQuery,
        Result<PagingSortingFiltering<AssetWarrantyStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetWarrantyStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetWarrantyStatusDetailsResponse>>> Handle(
        GetAllAssetWarrantyStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetWarrantyStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetWarrantyStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetWarrantyStatusDetailsResponse>>.Success(result);
    }
}
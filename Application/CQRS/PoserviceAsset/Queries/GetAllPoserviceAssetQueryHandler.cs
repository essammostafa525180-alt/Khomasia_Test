using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PoserviceAsset.Queries;

public class GetAllPoserviceAssetQuery
: IQuery<Result<PagingSortingFiltering<PoserviceAssetDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPoserviceAssetQueryHandler :
    IQueryHandler<GetAllPoserviceAssetQuery,
        Result<PagingSortingFiltering<PoserviceAssetDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPoserviceAssetQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PoserviceAssetDetailsResponse>>> Handle(
        GetAllPoserviceAssetQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PoserviceAssetRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PoserviceAssetDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PoserviceAssetDetailsResponse>>.Success(result);
    }
}
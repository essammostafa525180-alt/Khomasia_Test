using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetsGroup.Queries;

public class GetAllAssetsGroupQuery
: IQuery<Result<PagingSortingFiltering<AssetsGroupDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetsGroupQueryHandler :
    IQueryHandler<GetAllAssetsGroupQuery,
        Result<PagingSortingFiltering<AssetsGroupDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetsGroupQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetsGroupDetailsResponse>>> Handle(
        GetAllAssetsGroupQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetsGroupRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetsGroupDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetsGroupDetailsResponse>>.Success(result);
    }
}
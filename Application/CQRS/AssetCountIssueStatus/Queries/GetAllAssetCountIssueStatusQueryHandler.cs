using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCountIssueStatus.Queries;

public class GetAllAssetCountIssueStatusQuery
: IQuery<Result<PagingSortingFiltering<AssetCountIssueStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountIssueStatusQueryHandler :
    IQueryHandler<GetAllAssetCountIssueStatusQuery,
        Result<PagingSortingFiltering<AssetCountIssueStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountIssueStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountIssueStatusDetailsResponse>>> Handle(
        GetAllAssetCountIssueStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountIssueStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountIssueStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountIssueStatusDetailsResponse>>.Success(result);
    }
}
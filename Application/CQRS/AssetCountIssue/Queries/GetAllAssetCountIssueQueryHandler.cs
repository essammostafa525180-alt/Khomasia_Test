using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCountIssue.Queries;

public class GetAllAssetCountIssueQuery
: IQuery<Result<PagingSortingFiltering<AssetCountIssueDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountIssueQueryHandler :
    IQueryHandler<GetAllAssetCountIssueQuery,
        Result<PagingSortingFiltering<AssetCountIssueDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountIssueQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountIssueDetailsResponse>>> Handle(
        GetAllAssetCountIssueQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountIssueRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountIssueDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountIssueDetailsResponse>>.Success(result);
    }
}
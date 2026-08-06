using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ApprovalMatrixRange.Queries;

public class GetAllApprovalMatrixRangeQuery
: IQuery<Result<PagingSortingFiltering<ApprovalMatrixRangeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllApprovalMatrixRangeQueryHandler :
    IQueryHandler<GetAllApprovalMatrixRangeQuery,
        Result<PagingSortingFiltering<ApprovalMatrixRangeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllApprovalMatrixRangeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ApprovalMatrixRangeDetailsResponse>>> Handle(
        GetAllApprovalMatrixRangeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ApprovalMatrixRangeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ApprovalMatrixRangeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ApprovalMatrixRangeDetailsResponse>>.Success(result);
    }
}
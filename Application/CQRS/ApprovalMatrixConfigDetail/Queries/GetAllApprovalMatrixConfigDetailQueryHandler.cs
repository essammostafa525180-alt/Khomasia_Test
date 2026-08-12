using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ApprovalMatrixConfigDetail.Queries;

public class GetAllApprovalMatrixConfigDetailQuery
: IQuery<Result<PagingSortingFiltering<ApprovalMatrixConfigDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllApprovalMatrixConfigDetailQueryHandler :
    IQueryHandler<GetAllApprovalMatrixConfigDetailQuery,
        Result<PagingSortingFiltering<ApprovalMatrixConfigDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllApprovalMatrixConfigDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ApprovalMatrixConfigDetailDetailsResponse>>> Handle(
        GetAllApprovalMatrixConfigDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ApprovalMatrixConfigDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ApprovalMatrixConfigDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ApprovalMatrixConfigDetailDetailsResponse>>.Success(result);
    }
}
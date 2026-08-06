using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ApprovalMatrixDetail.Queries;

public class GetAllApprovalMatrixDetailQuery
: IQuery<Result<PagingSortingFiltering<ApprovalMatrixDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllApprovalMatrixDetailQueryHandler :
    IQueryHandler<GetAllApprovalMatrixDetailQuery,
        Result<PagingSortingFiltering<ApprovalMatrixDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllApprovalMatrixDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ApprovalMatrixDetailDetailsResponse>>> Handle(
        GetAllApprovalMatrixDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ApprovalMatrixDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ApprovalMatrixDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ApprovalMatrixDetailDetailsResponse>>.Success(result);
    }
}
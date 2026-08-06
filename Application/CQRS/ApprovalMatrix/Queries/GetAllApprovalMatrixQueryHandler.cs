using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ApprovalMatrix.Queries;

public class GetAllApprovalMatrixQuery
: IQuery<Result<PagingSortingFiltering<ApprovalMatrixDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllApprovalMatrixQueryHandler :
    IQueryHandler<GetAllApprovalMatrixQuery,
        Result<PagingSortingFiltering<ApprovalMatrixDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllApprovalMatrixQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ApprovalMatrixDetailsResponse>>> Handle(
        GetAllApprovalMatrixQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ApprovalMatrixRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ApprovalMatrixDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ApprovalMatrixDetailsResponse>>.Success(result);
    }
}
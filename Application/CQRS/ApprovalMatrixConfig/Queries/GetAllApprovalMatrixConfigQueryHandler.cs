using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ApprovalMatrixConfig.Queries;

public class GetAllApprovalMatrixConfigQuery
: IQuery<Result<PagingSortingFiltering<ApprovalMatrixConfigDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllApprovalMatrixConfigQueryHandler :
    IQueryHandler<GetAllApprovalMatrixConfigQuery,
        Result<PagingSortingFiltering<ApprovalMatrixConfigDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllApprovalMatrixConfigQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ApprovalMatrixConfigDetailsResponse>>> Handle(
        GetAllApprovalMatrixConfigQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ApprovalMatrixConfigRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ApprovalMatrixConfigDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ApprovalMatrixConfigDetailsResponse>>.Success(result);
    }
}
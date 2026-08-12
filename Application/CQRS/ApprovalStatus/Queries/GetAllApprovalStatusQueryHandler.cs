using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ApprovalStatus.Queries;

public class GetAllApprovalStatusQuery
: IQuery<Result<PagingSortingFiltering<ApprovalStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllApprovalStatusQueryHandler :
    IQueryHandler<GetAllApprovalStatusQuery,
        Result<PagingSortingFiltering<ApprovalStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllApprovalStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ApprovalStatusDetailsResponse>>> Handle(
        GetAllApprovalStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ApprovalStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ApprovalStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ApprovalStatusDetailsResponse>>.Success(result);
    }
}
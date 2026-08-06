using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ApprovalScreen.Queries;

public class GetAllApprovalScreenQuery
: IQuery<Result<PagingSortingFiltering<ApprovalScreenDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllApprovalScreenQueryHandler :
    IQueryHandler<GetAllApprovalScreenQuery,
        Result<PagingSortingFiltering<ApprovalScreenDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllApprovalScreenQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ApprovalScreenDetailsResponse>>> Handle(
        GetAllApprovalScreenQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ApprovalScreenRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ApprovalScreenDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ApprovalScreenDetailsResponse>>.Success(result);
    }
}
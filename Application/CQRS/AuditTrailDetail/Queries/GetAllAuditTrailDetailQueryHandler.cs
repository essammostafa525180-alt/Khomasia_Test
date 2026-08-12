using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AuditTrailDetail.Queries;

public class GetAllAuditTrailDetailQuery
: IQuery<Result<PagingSortingFiltering<AuditTrailDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAuditTrailDetailQueryHandler :
    IQueryHandler<GetAllAuditTrailDetailQuery,
        Result<PagingSortingFiltering<AuditTrailDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAuditTrailDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AuditTrailDetailDetailsResponse>>> Handle(
        GetAllAuditTrailDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AuditTrailDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AuditTrailDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AuditTrailDetailDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AuditTrail.Queries;

public class GetAllAuditTrailQuery
: IQuery<Result<PagingSortingFiltering<AuditTrailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAuditTrailQueryHandler :
    IQueryHandler<GetAllAuditTrailQuery,
        Result<PagingSortingFiltering<AuditTrailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAuditTrailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AuditTrailDetailsResponse>>> Handle(
        GetAllAuditTrailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AuditTrailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AuditTrailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AuditTrailDetailsResponse>>.Success(result);
    }
}
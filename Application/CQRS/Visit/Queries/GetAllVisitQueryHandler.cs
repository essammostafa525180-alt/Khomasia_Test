using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Visit.Queries;

public class GetAllVisitQuery
: IQuery<Result<PagingSortingFiltering<VisitDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVisitQueryHandler :
    IQueryHandler<GetAllVisitQuery,
        Result<PagingSortingFiltering<VisitDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVisitQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VisitDetailsResponse>>> Handle(
        GetAllVisitQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VisitRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VisitDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VisitDetailsResponse>>.Success(result);
    }
}
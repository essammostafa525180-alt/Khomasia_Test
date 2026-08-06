using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssignSiteSection.Queries;

public class GetAllAssignSiteSectionQuery
: IQuery<Result<PagingSortingFiltering<AssignSiteSectionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssignSiteSectionQueryHandler :
    IQueryHandler<GetAllAssignSiteSectionQuery,
        Result<PagingSortingFiltering<AssignSiteSectionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssignSiteSectionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssignSiteSectionDetailsResponse>>> Handle(
        GetAllAssignSiteSectionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssignSiteSectionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssignSiteSectionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssignSiteSectionDetailsResponse>>.Success(result);
    }
}
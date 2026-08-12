using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SubSection.Queries;

public class GetAllSubSectionQuery
: IQuery<Result<PagingSortingFiltering<SubSectionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSubSectionQueryHandler :
    IQueryHandler<GetAllSubSectionQuery,
        Result<PagingSortingFiltering<SubSectionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSubSectionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SubSectionDetailsResponse>>> Handle(
        GetAllSubSectionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SubSectionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SubSectionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SubSectionDetailsResponse>>.Success(result);
    }
}
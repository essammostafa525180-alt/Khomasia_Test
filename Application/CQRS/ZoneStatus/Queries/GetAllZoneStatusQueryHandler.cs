using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ZoneStatus.Queries;

public class GetAllZoneStatusQuery
: IQuery<Result<PagingSortingFiltering<ZoneStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllZoneStatusQueryHandler :
    IQueryHandler<GetAllZoneStatusQuery,
        Result<PagingSortingFiltering<ZoneStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllZoneStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ZoneStatusDetailsResponse>>> Handle(
        GetAllZoneStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ZoneStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ZoneStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ZoneStatusDetailsResponse>>.Success(result);
    }
}
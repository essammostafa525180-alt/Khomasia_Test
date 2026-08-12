using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Zone.Queries;

public class GetAllZoneQuery
: IQuery<Result<PagingSortingFiltering<ZoneDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllZoneQueryHandler :
    IQueryHandler<GetAllZoneQuery,
        Result<PagingSortingFiltering<ZoneDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllZoneQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ZoneDetailsResponse>>> Handle(
        GetAllZoneQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ZoneRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ZoneDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ZoneDetailsResponse>>.Success(result);
    }
}
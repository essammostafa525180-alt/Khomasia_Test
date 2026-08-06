using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Location.Queries;

public class GetAllLocationQuery
: IQuery<Result<PagingSortingFiltering<LocationDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllLocationQueryHandler :
    IQueryHandler<GetAllLocationQuery,
        Result<PagingSortingFiltering<LocationDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLocationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<LocationDetailsResponse>>> Handle(
        GetAllLocationQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.LocationRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<LocationDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<LocationDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AirFilterType.Queries;

public class GetAllAirFilterTypeQuery
: IQuery<Result<PagingSortingFiltering<AirFilterTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAirFilterTypeQueryHandler :
    IQueryHandler<GetAllAirFilterTypeQuery,
        Result<PagingSortingFiltering<AirFilterTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAirFilterTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AirFilterTypeDetailsResponse>>> Handle(
        GetAllAirFilterTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AirFilterTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AirFilterTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AirFilterTypeDetailsResponse>>.Success(result);
    }
}
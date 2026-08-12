using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.City.Queries;

public class GetAllCityQuery
: IQuery<Result<PagingSortingFiltering<CityDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCityQueryHandler :
    IQueryHandler<GetAllCityQuery,
        Result<PagingSortingFiltering<CityDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCityQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<CityDetailsResponse>>> Handle(
        GetAllCityQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CityRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<CityDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<CityDetailsResponse>>.Success(result);
    }
}
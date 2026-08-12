using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Country.Queries;

public class GetAllCountryQuery
: IQuery<Result<PagingSortingFiltering<CountryDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCountryQueryHandler :
    IQueryHandler<GetAllCountryQuery,
        Result<PagingSortingFiltering<CountryDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCountryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<CountryDetailsResponse>>> Handle(
        GetAllCountryQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CountryRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<CountryDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<CountryDetailsResponse>>.Success(result);
    }
}
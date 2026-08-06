using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.UnitOfMeasure.Queries;

public class GetAllUnitOfMeasureQuery
: IQuery<Result<PagingSortingFiltering<UnitOfMeasureDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllUnitOfMeasureQueryHandler :
    IQueryHandler<GetAllUnitOfMeasureQuery,
        Result<PagingSortingFiltering<UnitOfMeasureDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUnitOfMeasureQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<UnitOfMeasureDetailsResponse>>> Handle(
        GetAllUnitOfMeasureQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UnitOfMeasureRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<UnitOfMeasureDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<UnitOfMeasureDetailsResponse>>.Success(result);
    }
}
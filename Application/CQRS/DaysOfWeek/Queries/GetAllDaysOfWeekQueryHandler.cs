using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.DaysOfWeek.Queries;

public class GetAllDaysOfWeekQuery
: IQuery<Result<PagingSortingFiltering<DaysOfWeekDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllDaysOfWeekQueryHandler :
    IQueryHandler<GetAllDaysOfWeekQuery,
        Result<PagingSortingFiltering<DaysOfWeekDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDaysOfWeekQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<DaysOfWeekDetailsResponse>>> Handle(
        GetAllDaysOfWeekQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.DaysOfWeekRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<DaysOfWeekDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<DaysOfWeekDetailsResponse>>.Success(result);
    }
}
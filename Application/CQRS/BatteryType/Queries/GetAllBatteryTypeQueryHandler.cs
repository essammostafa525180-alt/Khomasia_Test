using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.BatteryType.Queries;

public class GetAllBatteryTypeQuery
: IQuery<Result<PagingSortingFiltering<BatteryTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllBatteryTypeQueryHandler :
    IQueryHandler<GetAllBatteryTypeQuery,
        Result<PagingSortingFiltering<BatteryTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBatteryTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<BatteryTypeDetailsResponse>>> Handle(
        GetAllBatteryTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.BatteryTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<BatteryTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<BatteryTypeDetailsResponse>>.Success(result);
    }
}
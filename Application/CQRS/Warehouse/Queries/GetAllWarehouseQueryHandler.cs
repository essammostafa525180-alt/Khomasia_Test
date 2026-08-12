using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Warehouse.Queries;

public class GetAllWarehouseQuery
: IQuery<Result<PagingSortingFiltering<WarehouseDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllWarehouseQueryHandler :
    IQueryHandler<GetAllWarehouseQuery,
        Result<PagingSortingFiltering<WarehouseDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWarehouseQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<WarehouseDetailsResponse>>> Handle(
        GetAllWarehouseQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.WarehouseRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<WarehouseDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<WarehouseDetailsResponse>>.Success(result);
    }
}

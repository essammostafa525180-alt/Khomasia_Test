using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.WarehouseType.Queries;

public class GetAllWarehouseTypeQuery
: IQuery<Result<PagingSortingFiltering<WarehouseTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllWarehouseTypeQueryHandler :
    IQueryHandler<GetAllWarehouseTypeQuery,
        Result<PagingSortingFiltering<WarehouseTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWarehouseTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<WarehouseTypeDetailsResponse>>> Handle(
        GetAllWarehouseTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.WarehouseTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<WarehouseTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<WarehouseTypeDetailsResponse>>.Success(result);
    }
}

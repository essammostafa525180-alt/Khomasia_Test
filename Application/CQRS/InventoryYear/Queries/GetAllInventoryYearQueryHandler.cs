using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryYear.Queries;

public class GetAllInventoryYearQuery
: IQuery<Result<PagingSortingFiltering<InventoryYearDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryYearQueryHandler :
    IQueryHandler<GetAllInventoryYearQuery,
        Result<PagingSortingFiltering<InventoryYearDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryYearQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryYearDetailsResponse>>> Handle(
        GetAllInventoryYearQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryYearRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryYearDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryYearDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryCurrency.Queries;

public class GetAllInventoryCurrencyQuery
: IQuery<Result<PagingSortingFiltering<InventoryCurrencyDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryCurrencyQueryHandler :
    IQueryHandler<GetAllInventoryCurrencyQuery,
        Result<PagingSortingFiltering<InventoryCurrencyDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryCurrencyQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryCurrencyDetailsResponse>>> Handle(
        GetAllInventoryCurrencyQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryCurrencyRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryCurrencyDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryCurrencyDetailsResponse>>.Success(result);
    }
}
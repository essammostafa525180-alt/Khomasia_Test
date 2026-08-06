using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SalesInvoiceItem.Queries;

public class GetAllSalesInvoiceItemQuery
: IQuery<Result<PagingSortingFiltering<SalesInvoiceItemDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSalesInvoiceItemQueryHandler :
    IQueryHandler<GetAllSalesInvoiceItemQuery,
        Result<PagingSortingFiltering<SalesInvoiceItemDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSalesInvoiceItemQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SalesInvoiceItemDetailsResponse>>> Handle(
        GetAllSalesInvoiceItemQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SalesInvoiceItemRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SalesInvoiceItemDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SalesInvoiceItemDetailsResponse>>.Success(result);
    }
}
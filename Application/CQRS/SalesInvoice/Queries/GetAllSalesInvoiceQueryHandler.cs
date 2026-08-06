using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SalesInvoice.Queries;

public class GetAllSalesInvoiceQuery
: IQuery<Result<PagingSortingFiltering<SalesInvoiceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSalesInvoiceQueryHandler :
    IQueryHandler<GetAllSalesInvoiceQuery,
        Result<PagingSortingFiltering<SalesInvoiceDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSalesInvoiceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SalesInvoiceDetailsResponse>>> Handle(
        GetAllSalesInvoiceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SalesInvoiceRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SalesInvoiceDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SalesInvoiceDetailsResponse>>.Success(result);
    }
}
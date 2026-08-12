using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SalesQuotation.Queries;

public class GetAllSalesQuotationQuery
: IQuery<Result<PagingSortingFiltering<SalesQuotationDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSalesQuotationQueryHandler :
    IQueryHandler<GetAllSalesQuotationQuery,
        Result<PagingSortingFiltering<SalesQuotationDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSalesQuotationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SalesQuotationDetailsResponse>>> Handle(
        GetAllSalesQuotationQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SalesQuotationRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SalesQuotationDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SalesQuotationDetailsResponse>>.Success(result);
    }
}
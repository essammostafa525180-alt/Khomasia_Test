using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SalesQuotationDetail.Queries;

public class GetAllSalesQuotationDetailQuery
: IQuery<Result<PagingSortingFiltering<SalesQuotationDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSalesQuotationDetailQueryHandler :
    IQueryHandler<GetAllSalesQuotationDetailQuery,
        Result<PagingSortingFiltering<SalesQuotationDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSalesQuotationDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SalesQuotationDetailDetailsResponse>>> Handle(
        GetAllSalesQuotationDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SalesQuotationDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SalesQuotationDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SalesQuotationDetailDetailsResponse>>.Success(result);
    }
}
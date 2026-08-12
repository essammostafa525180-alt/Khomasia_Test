using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PaymentTerm.Queries;

public class GetAllPaymentTermQuery
: IQuery<Result<PagingSortingFiltering<PaymentTermDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPaymentTermQueryHandler :
    IQueryHandler<GetAllPaymentTermQuery,
        Result<PagingSortingFiltering<PaymentTermDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPaymentTermQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PaymentTermDetailsResponse>>> Handle(
        GetAllPaymentTermQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PaymentTermRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PaymentTermDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PaymentTermDetailsResponse>>.Success(result);
    }
}
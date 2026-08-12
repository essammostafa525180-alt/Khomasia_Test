using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.OrderLineItemStatus.Queries;

public class GetAllOrderLineItemStatusQuery
: IQuery<Result<PagingSortingFiltering<OrderLineItemStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllOrderLineItemStatusQueryHandler :
    IQueryHandler<GetAllOrderLineItemStatusQuery,
        Result<PagingSortingFiltering<OrderLineItemStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrderLineItemStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<OrderLineItemStatusDetailsResponse>>> Handle(
        GetAllOrderLineItemStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.OrderLineItemStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<OrderLineItemStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<OrderLineItemStatusDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RequestLineItemStatus.Queries;

public class GetAllRequestLineItemStatusQuery
: IQuery<Result<PagingSortingFiltering<RequestLineItemStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRequestLineItemStatusQueryHandler :
    IQueryHandler<GetAllRequestLineItemStatusQuery,
        Result<PagingSortingFiltering<RequestLineItemStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRequestLineItemStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RequestLineItemStatusDetailsResponse>>> Handle(
        GetAllRequestLineItemStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RequestLineItemStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RequestLineItemStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RequestLineItemStatusDetailsResponse>>.Success(result);
    }
}
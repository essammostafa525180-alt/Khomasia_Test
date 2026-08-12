using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RwDeliveredQuantity.Queries;

public class GetAllRwDeliveredQuantityQuery
: IQuery<Result<PagingSortingFiltering<RwDeliveredQuantityDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRwDeliveredQuantityQueryHandler :
    IQueryHandler<GetAllRwDeliveredQuantityQuery,
        Result<PagingSortingFiltering<RwDeliveredQuantityDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRwDeliveredQuantityQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RwDeliveredQuantityDetailsResponse>>> Handle(
        GetAllRwDeliveredQuantityQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RwDeliveredQuantityRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RwDeliveredQuantityDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RwDeliveredQuantityDetailsResponse>>.Success(result);
    }
}
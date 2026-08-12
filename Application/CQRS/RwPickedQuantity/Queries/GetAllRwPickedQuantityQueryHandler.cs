using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RwPickedQuantity.Queries;

public class GetAllRwPickedQuantityQuery
: IQuery<Result<PagingSortingFiltering<RwPickedQuantityDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRwPickedQuantityQueryHandler :
    IQueryHandler<GetAllRwPickedQuantityQuery,
        Result<PagingSortingFiltering<RwPickedQuantityDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRwPickedQuantityQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RwPickedQuantityDetailsResponse>>> Handle(
        GetAllRwPickedQuantityQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RwPickedQuantityRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RwPickedQuantityDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RwPickedQuantityDetailsResponse>>.Success(result);
    }
}
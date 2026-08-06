using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Store.Queries;

public class GetAllStoreQuery
: IQuery<Result<PagingSortingFiltering<StoreDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllStoreQueryHandler :
    IQueryHandler<GetAllStoreQuery,
        Result<PagingSortingFiltering<StoreDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStoreQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<StoreDetailsResponse>>> Handle(
        GetAllStoreQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.StoreRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<StoreDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<StoreDetailsResponse>>.Success(result);
    }
}
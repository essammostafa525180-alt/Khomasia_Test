using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.StoreKeeper.Queries;

public class GetAllStoreKeeperQuery
: IQuery<Result<PagingSortingFiltering<StoreKeeperDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllStoreKeeperQueryHandler :
    IQueryHandler<GetAllStoreKeeperQuery,
        Result<PagingSortingFiltering<StoreKeeperDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStoreKeeperQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<StoreKeeperDetailsResponse>>> Handle(
        GetAllStoreKeeperQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.StoreKeeperRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<StoreKeeperDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<StoreKeeperDetailsResponse>>.Success(result);
    }
}
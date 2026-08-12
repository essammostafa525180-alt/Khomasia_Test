using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AnnualStockCount.Queries;

public class GetAllAnnualStockCountQuery
: IQuery<Result<PagingSortingFiltering<AnnualStockCountDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAnnualStockCountQueryHandler :
    IQueryHandler<GetAllAnnualStockCountQuery,
        Result<PagingSortingFiltering<AnnualStockCountDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAnnualStockCountQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AnnualStockCountDetailsResponse>>> Handle(
        GetAllAnnualStockCountQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AnnualStockCountRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AnnualStockCountDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AnnualStockCountDetailsResponse>>.Success(result);
    }
}
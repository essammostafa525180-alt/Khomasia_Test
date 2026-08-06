using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ItemBalanceStatus.Queries;

public class GetAllItemBalanceStatusQuery
: IQuery<Result<PagingSortingFiltering<ItemBalanceStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllItemBalanceStatusQueryHandler :
    IQueryHandler<GetAllItemBalanceStatusQuery,
        Result<PagingSortingFiltering<ItemBalanceStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllItemBalanceStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ItemBalanceStatusDetailsResponse>>> Handle(
        GetAllItemBalanceStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ItemBalanceStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ItemBalanceStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ItemBalanceStatusDetailsResponse>>.Success(result);
    }
}
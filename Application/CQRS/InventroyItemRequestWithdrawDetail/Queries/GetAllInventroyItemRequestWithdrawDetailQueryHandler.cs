using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventroyItemRequestWithdrawDetail.Queries;

public class GetAllInventroyItemRequestWithdrawDetailQuery
: IQuery<Result<PagingSortingFiltering<InventroyItemRequestWithdrawDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventroyItemRequestWithdrawDetailQueryHandler :
    IQueryHandler<GetAllInventroyItemRequestWithdrawDetailQuery,
        Result<PagingSortingFiltering<InventroyItemRequestWithdrawDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventroyItemRequestWithdrawDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventroyItemRequestWithdrawDetailDetailsResponse>>> Handle(
        GetAllInventroyItemRequestWithdrawDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventroyItemRequestWithdrawDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventroyItemRequestWithdrawDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventroyItemRequestWithdrawDetailDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventroyItemRequestWithdraw.Queries;

public class GetAllInventroyItemRequestWithdrawQuery
: IQuery<Result<PagingSortingFiltering<InventroyItemRequestWithdrawDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventroyItemRequestWithdrawQueryHandler :
    IQueryHandler<GetAllInventroyItemRequestWithdrawQuery,
        Result<PagingSortingFiltering<InventroyItemRequestWithdrawDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventroyItemRequestWithdrawQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventroyItemRequestWithdrawDetailsResponse>>> Handle(
        GetAllInventroyItemRequestWithdrawQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventroyItemRequestWithdrawRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventroyItemRequestWithdrawDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventroyItemRequestWithdrawDetailsResponse>>.Success(result);
    }
}
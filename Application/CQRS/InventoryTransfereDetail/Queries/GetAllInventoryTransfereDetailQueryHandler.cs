using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryTransfereDetail.Queries;

public class GetAllInventoryTransfereDetailQuery
: IQuery<Result<PagingSortingFiltering<InventoryTransfereDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryTransfereDetailQueryHandler :
    IQueryHandler<GetAllInventoryTransfereDetailQuery,
        Result<PagingSortingFiltering<InventoryTransfereDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryTransfereDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryTransfereDetailDetailsResponse>>> Handle(
        GetAllInventoryTransfereDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryTransfereDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryTransfereDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryTransfereDetailDetailsResponse>>.Success(result);
    }
}
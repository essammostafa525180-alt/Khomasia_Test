using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItem.Queries;

public class GetAllInventoryItemQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchText { get; set; }
}
public class GetAllInventoryItemQueryHandler :
    IQueryHandler<GetAllInventoryItemQuery,
        Result<PagingSortingFiltering<InventoryItemDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemDetailsResponse>>> Handle(
        GetAllInventoryItemQuery request,
        CancellationToken cancellationToken)
    {
        var query = _unitOfWork.InventoryItemRepository.GetQueryable()
                                    .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchText))
        {
            var term = request.SearchText.Trim();
            query = query.Where(x =>
                x.ItemNumber != null && x.ItemNumber.Contains(term) ||
                x.Name != null && x.Name.Contains(term) ||
                x.NameAr != null && x.NameAr.Contains(term) ||
                x.ItemCode != null && x.ItemCode.Contains(term) ||
                x.RFID != null && x.RFID.Contains(term));
        }

        var result = await query
                                    .ProjectToType<InventoryItemDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemDetailsResponse>>.Success(result);
    }
}





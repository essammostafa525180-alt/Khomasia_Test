using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemReturnAttachment.Queries;

public class GetAllInventoryItemReturnAttachmentQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemReturnAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemReturnAttachmentQueryHandler :
    IQueryHandler<GetAllInventoryItemReturnAttachmentQuery,
        Result<PagingSortingFiltering<InventoryItemReturnAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemReturnAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemReturnAttachmentDetailsResponse>>> Handle(
        GetAllInventoryItemReturnAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemReturnAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemReturnAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemReturnAttachmentDetailsResponse>>.Success(result);
    }
}
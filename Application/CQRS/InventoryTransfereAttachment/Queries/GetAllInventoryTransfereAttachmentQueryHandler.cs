using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryTransfereAttachment.Queries;

public class GetAllInventoryTransfereAttachmentQuery
: IQuery<Result<PagingSortingFiltering<InventoryTransfereAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryTransfereAttachmentQueryHandler :
    IQueryHandler<GetAllInventoryTransfereAttachmentQuery,
        Result<PagingSortingFiltering<InventoryTransfereAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryTransfereAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryTransfereAttachmentDetailsResponse>>> Handle(
        GetAllInventoryTransfereAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryTransfereAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryTransfereAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryTransfereAttachmentDetailsResponse>>.Success(result);
    }
}
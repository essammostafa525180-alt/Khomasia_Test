using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PurchaseOrderServiceAttachment.Queries;

public class GetAllPurchaseOrderServiceAttachmentQuery
: IQuery<Result<PagingSortingFiltering<PurchaseOrderServiceAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPurchaseOrderServiceAttachmentQueryHandler :
    IQueryHandler<GetAllPurchaseOrderServiceAttachmentQuery,
        Result<PagingSortingFiltering<PurchaseOrderServiceAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPurchaseOrderServiceAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PurchaseOrderServiceAttachmentDetailsResponse>>> Handle(
        GetAllPurchaseOrderServiceAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PurchaseOrderServiceAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PurchaseOrderServiceAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PurchaseOrderServiceAttachmentDetailsResponse>>.Success(result);
    }
}
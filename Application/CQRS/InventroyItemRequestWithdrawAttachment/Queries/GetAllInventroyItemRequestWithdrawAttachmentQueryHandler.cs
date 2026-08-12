using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventroyItemRequestWithdrawAttachment.Queries;

public class GetAllInventroyItemRequestWithdrawAttachmentQuery
: IQuery<Result<PagingSortingFiltering<InventroyItemRequestWithdrawAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventroyItemRequestWithdrawAttachmentQueryHandler :
    IQueryHandler<GetAllInventroyItemRequestWithdrawAttachmentQuery,
        Result<PagingSortingFiltering<InventroyItemRequestWithdrawAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventroyItemRequestWithdrawAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventroyItemRequestWithdrawAttachmentDetailsResponse>>> Handle(
        GetAllInventroyItemRequestWithdrawAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventroyItemRequestWithdrawAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventroyItemRequestWithdrawAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventroyItemRequestWithdrawAttachmentDetailsResponse>>.Success(result);
    }
}
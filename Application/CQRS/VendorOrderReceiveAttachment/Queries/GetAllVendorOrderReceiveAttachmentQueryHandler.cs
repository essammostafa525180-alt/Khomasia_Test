using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderReceiveAttachment.Queries;

public class GetAllVendorOrderReceiveAttachmentQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderReceiveAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderReceiveAttachmentQueryHandler :
    IQueryHandler<GetAllVendorOrderReceiveAttachmentQuery,
        Result<PagingSortingFiltering<VendorOrderReceiveAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderReceiveAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderReceiveAttachmentDetailsResponse>>> Handle(
        GetAllVendorOrderReceiveAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderReceiveAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderReceiveAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderReceiveAttachmentDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderAttachment.Queries;

public class GetAllVendorOrderAttachmentQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderAttachmentQueryHandler :
    IQueryHandler<GetAllVendorOrderAttachmentQuery,
        Result<PagingSortingFiltering<VendorOrderAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderAttachmentDetailsResponse>>> Handle(
        GetAllVendorOrderAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderAttachmentDetailsResponse>>.Success(result);
    }
}
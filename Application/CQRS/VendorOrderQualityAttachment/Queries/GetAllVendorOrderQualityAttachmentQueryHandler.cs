using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderQualityAttachment.Queries;

public class GetAllVendorOrderQualityAttachmentQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderQualityAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderQualityAttachmentQueryHandler :
    IQueryHandler<GetAllVendorOrderQualityAttachmentQuery,
        Result<PagingSortingFiltering<VendorOrderQualityAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderQualityAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderQualityAttachmentDetailsResponse>>> Handle(
        GetAllVendorOrderQualityAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderQualityAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderQualityAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderQualityAttachmentDetailsResponse>>.Success(result);
    }
}
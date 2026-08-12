using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorReturnAttachment.Queries;

public class GetAllVendorReturnAttachmentQuery
: IQuery<Result<PagingSortingFiltering<VendorReturnAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorReturnAttachmentQueryHandler :
    IQueryHandler<GetAllVendorReturnAttachmentQuery,
        Result<PagingSortingFiltering<VendorReturnAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorReturnAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorReturnAttachmentDetailsResponse>>> Handle(
        GetAllVendorReturnAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorReturnAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorReturnAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorReturnAttachmentDetailsResponse>>.Success(result);
    }
}
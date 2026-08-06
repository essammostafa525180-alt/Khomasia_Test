using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetItemAttachment.Queries;

public class GetAllAssetItemAttachmentQuery
: IQuery<Result<PagingSortingFiltering<AssetItemAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetItemAttachmentQueryHandler :
    IQueryHandler<GetAllAssetItemAttachmentQuery,
        Result<PagingSortingFiltering<AssetItemAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetItemAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetItemAttachmentDetailsResponse>>> Handle(
        GetAllAssetItemAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetItemAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetItemAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetItemAttachmentDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetAttachment.Queries;

public class GetAllAssetAttachmentQuery
: IQuery<Result<PagingSortingFiltering<AssetAttachmentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetAttachmentQueryHandler :
    IQueryHandler<GetAllAssetAttachmentQuery,
        Result<PagingSortingFiltering<AssetAttachmentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetAttachmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetAttachmentDetailsResponse>>> Handle(
        GetAllAssetAttachmentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetAttachmentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetAttachmentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetAttachmentDetailsResponse>>.Success(result);
    }
}
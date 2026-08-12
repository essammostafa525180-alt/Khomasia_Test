using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetItemAttachment.Queries;

public class GetAssetItemAttachmentByIdQuery : IQuery<Result<AssetItemAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetItemAttachmentByIdQueryHandler : IQueryHandler<GetAssetItemAttachmentByIdQuery, Result<AssetItemAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetItemAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetItemAttachmentDetailsResponse>> Handle(GetAssetItemAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetItemAttachmentDetailsResponse>.Failure(Errors.AssetItemAttachmentNotFound);

        var response = entity.Adapt<AssetItemAttachmentDetailsResponse>();

        return Result<AssetItemAttachmentDetailsResponse>.Success(response);
    }
}
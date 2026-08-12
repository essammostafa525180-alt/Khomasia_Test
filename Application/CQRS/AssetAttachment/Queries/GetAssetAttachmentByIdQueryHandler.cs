using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssetAttachment.Queries;

public class GetAssetAttachmentByIdQuery : IQuery<Result<AssetAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssetAttachmentByIdQueryHandler : IQueryHandler<GetAssetAttachmentByIdQuery, Result<AssetAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssetAttachmentDetailsResponse>> Handle(GetAssetAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssetAttachmentDetailsResponse>.Failure(Errors.AssetAttachmentNotFound);

        var response = entity.Adapt<AssetAttachmentDetailsResponse>();

        return Result<AssetAttachmentDetailsResponse>.Success(response);
    }
}
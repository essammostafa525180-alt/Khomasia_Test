using Application.Abstractions;

namespace Application.CQRS.AssetItemAttachment.Commands;

public class UpdateAssetItemAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetItemFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetItemAttachmentCommandHandler : ICommandHandler<UpdateAssetItemAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetItemAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetItemAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemAttachmentNotFound);

        entity.Update(request.AssetItemFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemAttachmentNotUpdated);
    }
}
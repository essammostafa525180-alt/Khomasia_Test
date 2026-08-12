using Application.Abstractions;

namespace Application.CQRS.AssetAttachment.Commands;

public class UpdateAssetAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetAttachmentCommandHandler : ICommandHandler<UpdateAssetAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetAttachmentNotFound);

        entity.Update(request.AssetFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetAttachmentNotUpdated);
    }
}
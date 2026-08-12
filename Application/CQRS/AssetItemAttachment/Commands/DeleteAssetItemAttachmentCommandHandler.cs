using Application.Abstractions;

namespace Application.CQRS.AssetItemAttachment.Commands;

public class DeleteAssetItemAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetItemAttachmentCommandHandler : ICommandHandler<DeleteAssetItemAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetItemAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetItemAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemAttachmentNotFound);

        _unitOfWork.AssetItemAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemAttachmentNotDeleted);
    }
}
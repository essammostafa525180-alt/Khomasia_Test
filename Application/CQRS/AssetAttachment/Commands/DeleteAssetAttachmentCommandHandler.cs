using Application.Abstractions;

namespace Application.CQRS.AssetAttachment.Commands;

public class DeleteAssetAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetAttachmentCommandHandler : ICommandHandler<DeleteAssetAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetAttachmentNotFound);

        _unitOfWork.AssetAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetAttachmentNotDeleted);
    }
}
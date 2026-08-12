using Application.Abstractions;

namespace Application.CQRS.AssetItemAttachment.Commands;

public class CreateAssetItemAttachmentCommand : ICommand<Result<int>>
{
        public int? AssetItemFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetItemAttachmentCommandHandler : ICommandHandler<CreateAssetItemAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetItemAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetItemAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetItemAttachment.Create(request.AssetItemFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.AssetItemAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetItemAttachmentNotInserted);
    }
}
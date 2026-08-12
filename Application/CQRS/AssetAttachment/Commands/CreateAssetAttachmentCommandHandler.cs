using Application.Abstractions;

namespace Application.CQRS.AssetAttachment.Commands;

public class CreateAssetAttachmentCommand : ICommand<Result<int>>
{
        public int? AssetFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetAttachmentCommandHandler : ICommandHandler<CreateAssetAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetAttachment.Create(request.AssetFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.AssetAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetAttachmentNotInserted);
    }
}
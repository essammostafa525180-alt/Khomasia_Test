using Application.Abstractions;

namespace Application.CQRS.InventroyItemRequestWithdrawAttachment.Commands;

public class UpdateInventroyItemRequestWithdrawAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventroyItemRequestWithdrawFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventroyItemRequestWithdrawAttachmentCommandHandler : ICommandHandler<UpdateInventroyItemRequestWithdrawAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventroyItemRequestWithdrawAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventroyItemRequestWithdrawAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventroyItemRequestWithdrawAttachmentNotFound);

        entity.Update(request.InventroyItemRequestWithdrawFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventroyItemRequestWithdrawAttachmentNotUpdated);
    }
}
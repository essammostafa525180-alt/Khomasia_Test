using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereAttachment.Commands;

public class UpdateInventoryTransfereAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryTransfereFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryTransfereAttachmentCommandHandler : ICommandHandler<UpdateInventoryTransfereAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryTransfereAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryTransfereAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereAttachmentNotFound);

        entity.Update(request.InventoryTransfereFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereAttachmentNotUpdated);
    }
}
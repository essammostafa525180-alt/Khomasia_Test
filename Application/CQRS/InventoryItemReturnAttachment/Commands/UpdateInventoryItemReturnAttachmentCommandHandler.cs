using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnAttachment.Commands;

public class UpdateInventoryItemReturnAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryItemReturnFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemReturnAttachmentCommandHandler : ICommandHandler<UpdateInventoryItemReturnAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemReturnAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemReturnAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnAttachmentNotFound);

        entity.Update(request.InventoryItemReturnFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnAttachmentNotUpdated);
    }
}
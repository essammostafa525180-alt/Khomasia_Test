using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnAttachment.Commands;

public class DeleteInventoryItemReturnAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemReturnAttachmentCommandHandler : ICommandHandler<DeleteInventoryItemReturnAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemReturnAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemReturnAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnAttachmentNotFound);

        _unitOfWork.InventoryItemReturnAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnAttachmentNotDeleted);
    }
}
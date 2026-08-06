using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereAttachment.Commands;

public class DeleteInventoryTransfereAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryTransfereAttachmentCommandHandler : ICommandHandler<DeleteInventoryTransfereAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryTransfereAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryTransfereAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereAttachmentNotFound);

        _unitOfWork.InventoryTransfereAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereAttachmentNotDeleted);
    }
}
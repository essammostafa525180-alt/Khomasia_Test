using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereAttachment.Commands;

public class CreateInventoryTransfereAttachmentCommand : ICommand<Result<int>>
{
        public int? InventoryTransfereFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryTransfereAttachmentCommandHandler : ICommandHandler<CreateInventoryTransfereAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryTransfereAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryTransfereAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryTransfereAggregate.InventoryTransfereAttachment.Create(request.InventoryTransfereFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.InventoryTransfereAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryTransfereAttachmentNotInserted);
    }
}
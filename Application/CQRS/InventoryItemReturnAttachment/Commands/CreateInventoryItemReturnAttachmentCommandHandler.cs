using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnAttachment.Commands;

public class CreateInventoryItemReturnAttachmentCommand : ICommand<Result<int>>
{
        public int? InventoryItemReturnFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemReturnAttachmentCommandHandler : ICommandHandler<CreateInventoryItemReturnAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemReturnAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemReturnAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemReturnAttachment.Create(request.InventoryItemReturnFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.InventoryItemReturnAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemReturnAttachmentNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.PurchaseOrderServiceAttachment.Commands;

public class CreatePurchaseOrderServiceAttachmentCommand : ICommand<Result<int>>
{
        public int? PurchaseOrderServiceFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePurchaseOrderServiceAttachmentCommandHandler : ICommandHandler<CreatePurchaseOrderServiceAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePurchaseOrderServiceAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePurchaseOrderServiceAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.PurchaseOrderServiceAttachment.Create(request.PurchaseOrderServiceFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.PurchaseOrderServiceAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PurchaseOrderServiceAttachmentNotInserted);
    }
}
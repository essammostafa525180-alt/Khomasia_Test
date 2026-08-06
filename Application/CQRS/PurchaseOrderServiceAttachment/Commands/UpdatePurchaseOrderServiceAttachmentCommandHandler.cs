using Application.Abstractions;

namespace Application.CQRS.PurchaseOrderServiceAttachment.Commands;

public class UpdatePurchaseOrderServiceAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? PurchaseOrderServiceFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePurchaseOrderServiceAttachmentCommandHandler : ICommandHandler<UpdatePurchaseOrderServiceAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePurchaseOrderServiceAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePurchaseOrderServiceAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PurchaseOrderServiceAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PurchaseOrderServiceAttachmentNotFound);

        entity.Update(request.PurchaseOrderServiceFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PurchaseOrderServiceAttachmentNotUpdated);
    }
}
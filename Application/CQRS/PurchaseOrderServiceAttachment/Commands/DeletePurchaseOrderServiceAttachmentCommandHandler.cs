using Application.Abstractions;

namespace Application.CQRS.PurchaseOrderServiceAttachment.Commands;

public class DeletePurchaseOrderServiceAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePurchaseOrderServiceAttachmentCommandHandler : ICommandHandler<DeletePurchaseOrderServiceAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePurchaseOrderServiceAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePurchaseOrderServiceAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PurchaseOrderServiceAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PurchaseOrderServiceAttachmentNotFound);

        _unitOfWork.PurchaseOrderServiceAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PurchaseOrderServiceAttachmentNotDeleted);
    }
}
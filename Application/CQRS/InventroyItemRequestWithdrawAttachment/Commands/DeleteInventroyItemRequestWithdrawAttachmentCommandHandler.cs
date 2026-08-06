using Application.Abstractions;

namespace Application.CQRS.InventroyItemRequestWithdrawAttachment.Commands;

public class DeleteInventroyItemRequestWithdrawAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventroyItemRequestWithdrawAttachmentCommandHandler : ICommandHandler<DeleteInventroyItemRequestWithdrawAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventroyItemRequestWithdrawAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventroyItemRequestWithdrawAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventroyItemRequestWithdrawAttachmentNotFound);

        _unitOfWork.InventroyItemRequestWithdrawAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventroyItemRequestWithdrawAttachmentNotDeleted);
    }
}
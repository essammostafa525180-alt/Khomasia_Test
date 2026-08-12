using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveAttachment.Commands;

public class DeleteVendorOrderReceiveAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderReceiveAttachmentCommandHandler : ICommandHandler<DeleteVendorOrderReceiveAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderReceiveAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderReceiveAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveAttachmentNotFound);

        _unitOfWork.VendorOrderReceiveAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveAttachmentNotDeleted);
    }
}
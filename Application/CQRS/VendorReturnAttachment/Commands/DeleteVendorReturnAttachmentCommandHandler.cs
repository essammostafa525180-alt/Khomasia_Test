using Application.Abstractions;

namespace Application.CQRS.VendorReturnAttachment.Commands;

public class DeleteVendorReturnAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorReturnAttachmentCommandHandler : ICommandHandler<DeleteVendorReturnAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorReturnAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorReturnAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnAttachmentNotFound);

        _unitOfWork.VendorReturnAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnAttachmentNotDeleted);
    }
}
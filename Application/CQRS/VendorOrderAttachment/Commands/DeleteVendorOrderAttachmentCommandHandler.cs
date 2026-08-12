using Application.Abstractions;

namespace Application.CQRS.VendorOrderAttachment.Commands;

public class DeleteVendorOrderAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderAttachmentCommandHandler : ICommandHandler<DeleteVendorOrderAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderAttachmentNotFound);

        _unitOfWork.VendorOrderAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderAttachmentNotDeleted);
    }
}
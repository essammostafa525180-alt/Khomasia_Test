using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityAttachment.Commands;

public class DeleteVendorOrderQualityAttachmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorOrderQualityAttachmentCommandHandler : ICommandHandler<DeleteVendorOrderQualityAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorOrderQualityAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorOrderQualityAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderQualityAttachmentNotFound);

        _unitOfWork.VendorOrderQualityAttachmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderQualityAttachmentNotDeleted);
    }
}
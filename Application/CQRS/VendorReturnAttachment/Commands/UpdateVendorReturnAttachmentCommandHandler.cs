using Application.Abstractions;

namespace Application.CQRS.VendorReturnAttachment.Commands;

public class UpdateVendorReturnAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorReturnFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorReturnAttachmentCommandHandler : ICommandHandler<UpdateVendorReturnAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorReturnAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorReturnAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnAttachmentNotFound);

        entity.Update(request.VendorReturnFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnAttachmentNotUpdated);
    }
}
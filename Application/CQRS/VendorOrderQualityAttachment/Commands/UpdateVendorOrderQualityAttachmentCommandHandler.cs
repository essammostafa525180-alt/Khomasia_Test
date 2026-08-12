using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityAttachment.Commands;

public class UpdateVendorOrderQualityAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderQualityFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderQualityAttachmentCommandHandler : ICommandHandler<UpdateVendorOrderQualityAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderQualityAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderQualityAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderQualityAttachmentNotFound);

        entity.Update(request.VendorOrderQualityFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderQualityAttachmentNotUpdated);
    }
}
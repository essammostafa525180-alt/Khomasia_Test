using Application.Abstractions;

namespace Application.CQRS.VendorOrderAttachment.Commands;

public class UpdateVendorOrderAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderAttachmentCommandHandler : ICommandHandler<UpdateVendorOrderAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderAttachmentNotFound);

        entity.Update(request.VendorOrderFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderAttachmentNotUpdated);
    }
}
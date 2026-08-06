using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveAttachment.Commands;

public class UpdateVendorOrderReceiveAttachmentCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderReceiveFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderReceiveAttachmentCommandHandler : ICommandHandler<UpdateVendorOrderReceiveAttachmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderReceiveAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderReceiveAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveAttachmentNotFound);

        entity.Update(request.VendorOrderReceiveFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveAttachmentNotUpdated);
    }
}
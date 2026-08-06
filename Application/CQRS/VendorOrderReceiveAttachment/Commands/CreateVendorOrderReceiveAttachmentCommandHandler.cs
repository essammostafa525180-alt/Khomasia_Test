using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveAttachment.Commands;

public class CreateVendorOrderReceiveAttachmentCommand : ICommand<Result<int>>
{
        public int? VendorOrderReceiveFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderReceiveAttachmentCommandHandler : ICommandHandler<CreateVendorOrderReceiveAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderReceiveAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderReceiveAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderReceiveAttachment.Create(request.VendorOrderReceiveFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.VendorOrderReceiveAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderReceiveAttachmentNotInserted);
    }
}
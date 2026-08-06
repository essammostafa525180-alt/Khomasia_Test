using Application.Abstractions;

namespace Application.CQRS.VendorOrderAttachment.Commands;

public class CreateVendorOrderAttachmentCommand : ICommand<Result<int>>
{
        public int? VendorOrderFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderAttachmentCommandHandler : ICommandHandler<CreateVendorOrderAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderAttachment.Create(request.VendorOrderFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.VendorOrderAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderAttachmentNotInserted);
    }
}
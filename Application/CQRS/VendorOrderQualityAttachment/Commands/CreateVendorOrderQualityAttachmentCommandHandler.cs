using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityAttachment.Commands;

public class CreateVendorOrderQualityAttachmentCommand : ICommand<Result<int>>
{
        public int? VendorOrderQualityFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderQualityAttachmentCommandHandler : ICommandHandler<CreateVendorOrderQualityAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderQualityAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderQualityAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderQualityAttachment.Create(request.VendorOrderQualityFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.VendorOrderQualityAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderQualityAttachmentNotInserted);
    }
}
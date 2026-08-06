using Application.Abstractions;

namespace Application.CQRS.VendorReturnAttachment.Commands;

public class CreateVendorReturnAttachmentCommand : ICommand<Result<int>>
{
        public int? VendorReturnFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorReturnAttachmentCommandHandler : ICommandHandler<CreateVendorReturnAttachmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorReturnAttachmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorReturnAttachmentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorReturnAggregate.VendorReturnAttachment.Create(request.VendorReturnFk, request.AttachmentId, request.AttachmentName, request.Description, request.IsActive);

        await _unitOfWork.VendorReturnAttachmentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorReturnAttachmentNotInserted);
    }
}
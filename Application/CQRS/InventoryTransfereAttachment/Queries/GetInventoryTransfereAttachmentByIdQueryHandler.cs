using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryTransfereAttachment.Queries;

public class GetInventoryTransfereAttachmentByIdQuery : IQuery<Result<InventoryTransfereAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryTransfereAttachmentByIdQueryHandler : IQueryHandler<GetInventoryTransfereAttachmentByIdQuery, Result<InventoryTransfereAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryTransfereAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryTransfereAttachmentDetailsResponse>> Handle(GetInventoryTransfereAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryTransfereAttachmentDetailsResponse>.Failure(Errors.InventoryTransfereAttachmentNotFound);

        var response = entity.Adapt<InventoryTransfereAttachmentDetailsResponse>();

        return Result<InventoryTransfereAttachmentDetailsResponse>.Success(response);
    }
}
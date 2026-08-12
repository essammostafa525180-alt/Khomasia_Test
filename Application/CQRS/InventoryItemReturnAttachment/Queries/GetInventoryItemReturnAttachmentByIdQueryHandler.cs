using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemReturnAttachment.Queries;

public class GetInventoryItemReturnAttachmentByIdQuery : IQuery<Result<InventoryItemReturnAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemReturnAttachmentByIdQueryHandler : IQueryHandler<GetInventoryItemReturnAttachmentByIdQuery, Result<InventoryItemReturnAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemReturnAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemReturnAttachmentDetailsResponse>> Handle(GetInventoryItemReturnAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemReturnAttachmentDetailsResponse>.Failure(Errors.InventoryItemReturnAttachmentNotFound);

        var response = entity.Adapt<InventoryItemReturnAttachmentDetailsResponse>();

        return Result<InventoryItemReturnAttachmentDetailsResponse>.Success(response);
    }
}
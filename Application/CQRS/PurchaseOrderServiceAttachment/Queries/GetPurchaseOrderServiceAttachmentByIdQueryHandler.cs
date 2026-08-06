using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PurchaseOrderServiceAttachment.Queries;

public class GetPurchaseOrderServiceAttachmentByIdQuery : IQuery<Result<PurchaseOrderServiceAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPurchaseOrderServiceAttachmentByIdQueryHandler : IQueryHandler<GetPurchaseOrderServiceAttachmentByIdQuery, Result<PurchaseOrderServiceAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPurchaseOrderServiceAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PurchaseOrderServiceAttachmentDetailsResponse>> Handle(GetPurchaseOrderServiceAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PurchaseOrderServiceAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PurchaseOrderServiceAttachmentDetailsResponse>.Failure(Errors.PurchaseOrderServiceAttachmentNotFound);

        var response = entity.Adapt<PurchaseOrderServiceAttachmentDetailsResponse>();

        return Result<PurchaseOrderServiceAttachmentDetailsResponse>.Success(response);
    }
}
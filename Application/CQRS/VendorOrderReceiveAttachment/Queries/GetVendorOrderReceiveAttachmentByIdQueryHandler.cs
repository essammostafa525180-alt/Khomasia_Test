using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderReceiveAttachment.Queries;

public class GetVendorOrderReceiveAttachmentByIdQuery : IQuery<Result<VendorOrderReceiveAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderReceiveAttachmentByIdQueryHandler : IQueryHandler<GetVendorOrderReceiveAttachmentByIdQuery, Result<VendorOrderReceiveAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderReceiveAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderReceiveAttachmentDetailsResponse>> Handle(GetVendorOrderReceiveAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderReceiveAttachmentDetailsResponse>.Failure(Errors.VendorOrderReceiveAttachmentNotFound);

        var response = entity.Adapt<VendorOrderReceiveAttachmentDetailsResponse>();

        return Result<VendorOrderReceiveAttachmentDetailsResponse>.Success(response);
    }
}
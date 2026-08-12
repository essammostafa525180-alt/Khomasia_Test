using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderQualityAttachment.Queries;

public class GetVendorOrderQualityAttachmentByIdQuery : IQuery<Result<VendorOrderQualityAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderQualityAttachmentByIdQueryHandler : IQueryHandler<GetVendorOrderQualityAttachmentByIdQuery, Result<VendorOrderQualityAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderQualityAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderQualityAttachmentDetailsResponse>> Handle(GetVendorOrderQualityAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderQualityAttachmentDetailsResponse>.Failure(Errors.VendorOrderQualityAttachmentNotFound);

        var response = entity.Adapt<VendorOrderQualityAttachmentDetailsResponse>();

        return Result<VendorOrderQualityAttachmentDetailsResponse>.Success(response);
    }
}
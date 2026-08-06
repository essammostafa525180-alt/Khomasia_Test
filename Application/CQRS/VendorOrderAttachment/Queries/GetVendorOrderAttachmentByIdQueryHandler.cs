using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderAttachment.Queries;

public class GetVendorOrderAttachmentByIdQuery : IQuery<Result<VendorOrderAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderAttachmentByIdQueryHandler : IQueryHandler<GetVendorOrderAttachmentByIdQuery, Result<VendorOrderAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderAttachmentDetailsResponse>> Handle(GetVendorOrderAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderAttachmentDetailsResponse>.Failure(Errors.VendorOrderAttachmentNotFound);

        var response = entity.Adapt<VendorOrderAttachmentDetailsResponse>();

        return Result<VendorOrderAttachmentDetailsResponse>.Success(response);
    }
}
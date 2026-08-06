using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorReturnAttachment.Queries;

public class GetVendorReturnAttachmentByIdQuery : IQuery<Result<VendorReturnAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorReturnAttachmentByIdQueryHandler : IQueryHandler<GetVendorReturnAttachmentByIdQuery, Result<VendorReturnAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorReturnAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorReturnAttachmentDetailsResponse>> Handle(GetVendorReturnAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorReturnAttachmentDetailsResponse>.Failure(Errors.VendorReturnAttachmentNotFound);

        var response = entity.Adapt<VendorReturnAttachmentDetailsResponse>();

        return Result<VendorReturnAttachmentDetailsResponse>.Success(response);
    }
}
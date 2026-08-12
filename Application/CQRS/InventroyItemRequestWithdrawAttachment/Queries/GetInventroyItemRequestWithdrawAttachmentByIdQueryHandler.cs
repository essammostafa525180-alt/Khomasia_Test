using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventroyItemRequestWithdrawAttachment.Queries;

public class GetInventroyItemRequestWithdrawAttachmentByIdQuery : IQuery<Result<InventroyItemRequestWithdrawAttachmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventroyItemRequestWithdrawAttachmentByIdQueryHandler : IQueryHandler<GetInventroyItemRequestWithdrawAttachmentByIdQuery, Result<InventroyItemRequestWithdrawAttachmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventroyItemRequestWithdrawAttachmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventroyItemRequestWithdrawAttachmentDetailsResponse>> Handle(GetInventroyItemRequestWithdrawAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawAttachmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventroyItemRequestWithdrawAttachmentDetailsResponse>.Failure(Errors.InventroyItemRequestWithdrawAttachmentNotFound);

        var response = entity.Adapt<InventroyItemRequestWithdrawAttachmentDetailsResponse>();

        return Result<InventroyItemRequestWithdrawAttachmentDetailsResponse>.Success(response);
    }
}
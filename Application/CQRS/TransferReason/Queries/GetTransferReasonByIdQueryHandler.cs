using Application.Abstractions;
using Mapster;

namespace Application.CQRS.TransferReason.Queries;

public class GetTransferReasonByIdQuery : IQuery<Result<TransferReasonDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetTransferReasonByIdQueryHandler : IQueryHandler<GetTransferReasonByIdQuery, Result<TransferReasonDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransferReasonByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TransferReasonDetailsResponse>> Handle(GetTransferReasonByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransferReasonRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<TransferReasonDetailsResponse>.Failure(Errors.TransferReasonNotFound);

        var response = entity.Adapt<TransferReasonDetailsResponse>();

        return Result<TransferReasonDetailsResponse>.Success(response);
    }
}
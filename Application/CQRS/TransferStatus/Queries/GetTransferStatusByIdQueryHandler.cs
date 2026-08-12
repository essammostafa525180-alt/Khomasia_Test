using Application.Abstractions;
using Mapster;

namespace Application.CQRS.TransferStatus.Queries;

public class GetTransferStatusByIdQuery : IQuery<Result<TransferStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetTransferStatusByIdQueryHandler : IQueryHandler<GetTransferStatusByIdQuery, Result<TransferStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransferStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TransferStatusDetailsResponse>> Handle(GetTransferStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransferStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<TransferStatusDetailsResponse>.Failure(Errors.TransferStatusNotFound);

        var response = entity.Adapt<TransferStatusDetailsResponse>();

        return Result<TransferStatusDetailsResponse>.Success(response);
    }
}
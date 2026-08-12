using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemReturnBatchSerial.Queries;

public class GetInventoryItemReturnBatchSerialByIdQuery : IQuery<Result<InventoryItemReturnBatchSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemReturnBatchSerialByIdQueryHandler : IQueryHandler<GetInventoryItemReturnBatchSerialByIdQuery, Result<InventoryItemReturnBatchSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemReturnBatchSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemReturnBatchSerialDetailsResponse>> Handle(GetInventoryItemReturnBatchSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemReturnBatchSerialDetailsResponse>.Failure(Errors.InventoryItemReturnBatchSerialNotFound);

        var response = entity.Adapt<InventoryItemReturnBatchSerialDetailsResponse>();

        return Result<InventoryItemReturnBatchSerialDetailsResponse>.Success(response);
    }
}
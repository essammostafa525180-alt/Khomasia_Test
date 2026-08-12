using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemLocationBatchSerial.Queries;

public class GetInventoryItemLocationBatchSerialByIdQuery : IQuery<Result<InventoryItemLocationBatchSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemLocationBatchSerialByIdQueryHandler : IQueryHandler<GetInventoryItemLocationBatchSerialByIdQuery, Result<InventoryItemLocationBatchSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemLocationBatchSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemLocationBatchSerialDetailsResponse>> Handle(GetInventoryItemLocationBatchSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemLocationBatchSerialDetailsResponse>.Failure(Errors.InventoryItemLocationBatchSerialNotFound);

        var response = entity.Adapt<InventoryItemLocationBatchSerialDetailsResponse>();

        return Result<InventoryItemLocationBatchSerialDetailsResponse>.Success(response);
    }
}
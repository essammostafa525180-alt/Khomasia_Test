using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryTransfereDetailBatchSerial.Queries;

public class GetInventoryTransfereDetailBatchSerialByIdQuery : IQuery<Result<InventoryTransfereDetailBatchSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryTransfereDetailBatchSerialByIdQueryHandler : IQueryHandler<GetInventoryTransfereDetailBatchSerialByIdQuery, Result<InventoryTransfereDetailBatchSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryTransfereDetailBatchSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryTransfereDetailBatchSerialDetailsResponse>> Handle(GetInventoryTransfereDetailBatchSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryTransfereDetailBatchSerialDetailsResponse>.Failure(Errors.InventoryTransfereDetailBatchSerialNotFound);

        var response = entity.Adapt<InventoryTransfereDetailBatchSerialDetailsResponse>();

        return Result<InventoryTransfereDetailBatchSerialDetailsResponse>.Success(response);
    }
}
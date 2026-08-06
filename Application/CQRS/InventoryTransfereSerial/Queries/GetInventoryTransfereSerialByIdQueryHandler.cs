using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryTransfereSerial.Queries;

public class GetInventoryTransfereSerialByIdQuery : IQuery<Result<InventoryTransfereSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryTransfereSerialByIdQueryHandler : IQueryHandler<GetInventoryTransfereSerialByIdQuery, Result<InventoryTransfereSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryTransfereSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryTransfereSerialDetailsResponse>> Handle(GetInventoryTransfereSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryTransfereSerialDetailsResponse>.Failure(Errors.InventoryTransfereSerialNotFound);

        var response = entity.Adapt<InventoryTransfereSerialDetailsResponse>();

        return Result<InventoryTransfereSerialDetailsResponse>.Success(response);
    }
}
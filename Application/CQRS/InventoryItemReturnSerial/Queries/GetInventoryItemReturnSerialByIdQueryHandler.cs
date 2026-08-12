using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemReturnSerial.Queries;

public class GetInventoryItemReturnSerialByIdQuery : IQuery<Result<InventoryItemReturnSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemReturnSerialByIdQueryHandler : IQueryHandler<GetInventoryItemReturnSerialByIdQuery, Result<InventoryItemReturnSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemReturnSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemReturnSerialDetailsResponse>> Handle(GetInventoryItemReturnSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemReturnSerialDetailsResponse>.Failure(Errors.InventoryItemReturnSerialNotFound);

        var response = entity.Adapt<InventoryItemReturnSerialDetailsResponse>();

        return Result<InventoryItemReturnSerialDetailsResponse>.Success(response);
    }
}
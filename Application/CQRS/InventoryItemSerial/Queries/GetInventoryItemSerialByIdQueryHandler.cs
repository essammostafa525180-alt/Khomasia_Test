using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemSerial.Queries;

public class GetInventoryItemSerialByIdQuery : IQuery<Result<InventoryItemSerialDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemSerialByIdQueryHandler : IQueryHandler<GetInventoryItemSerialByIdQuery, Result<InventoryItemSerialDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemSerialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemSerialDetailsResponse>> Handle(GetInventoryItemSerialByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemSerialDetailsResponse>.Failure(Errors.InventoryItemSerialNotFound);

        var response = entity.Adapt<InventoryItemSerialDetailsResponse>();

        return Result<InventoryItemSerialDetailsResponse>.Success(response);
    }
}
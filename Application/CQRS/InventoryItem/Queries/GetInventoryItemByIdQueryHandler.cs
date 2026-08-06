using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItem.Queries;

public class GetInventoryItemByIdQuery : IQuery<Result<InventoryItemDetailsResponse>>
{
    public long Id { get; set; }
}
internal class GetInventoryItemByIdQueryHandler : IQueryHandler<GetInventoryItemByIdQuery, Result<InventoryItemDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemDetailsResponse>> Handle(GetInventoryItemByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemDetailsResponse>.Failure(Errors.InventoryItemNotFound);

        var response = entity.Adapt<InventoryItemDetailsResponse>();

        return Result<InventoryItemDetailsResponse>.Success(response);
    }
}
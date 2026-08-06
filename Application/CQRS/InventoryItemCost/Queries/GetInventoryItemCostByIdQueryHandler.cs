using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemCost.Queries;

public class GetInventoryItemCostByIdQuery : IQuery<Result<InventoryItemCostDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemCostByIdQueryHandler : IQueryHandler<GetInventoryItemCostByIdQuery, Result<InventoryItemCostDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemCostByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemCostDetailsResponse>> Handle(GetInventoryItemCostByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemCostRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemCostDetailsResponse>.Failure(Errors.InventoryItemCostNotFound);

        var response = entity.Adapt<InventoryItemCostDetailsResponse>();

        return Result<InventoryItemCostDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryStockCountPlan.Queries;

public class GetInventoryStockCountPlanByIdQuery : IQuery<Result<InventoryStockCountPlanDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryStockCountPlanByIdQueryHandler : IQueryHandler<GetInventoryStockCountPlanByIdQuery, Result<InventoryStockCountPlanDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryStockCountPlanByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryStockCountPlanDetailsResponse>> Handle(GetInventoryStockCountPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountPlanRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryStockCountPlanDetailsResponse>.Failure(Errors.InventoryStockCountPlanNotFound);

        var response = entity.Adapt<InventoryStockCountPlanDetailsResponse>();

        return Result<InventoryStockCountPlanDetailsResponse>.Success(response);
    }
}
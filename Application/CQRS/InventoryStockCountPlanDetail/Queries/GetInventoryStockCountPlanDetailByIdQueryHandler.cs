using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryStockCountPlanDetail.Queries;

public class GetInventoryStockCountPlanDetailByIdQuery : IQuery<Result<InventoryStockCountPlanDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryStockCountPlanDetailByIdQueryHandler : IQueryHandler<GetInventoryStockCountPlanDetailByIdQuery, Result<InventoryStockCountPlanDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryStockCountPlanDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryStockCountPlanDetailDetailsResponse>> Handle(GetInventoryStockCountPlanDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountPlanDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryStockCountPlanDetailDetailsResponse>.Failure(Errors.InventoryStockCountPlanDetailNotFound);

        var response = entity.Adapt<InventoryStockCountPlanDetailDetailsResponse>();

        return Result<InventoryStockCountPlanDetailDetailsResponse>.Success(response);
    }
}
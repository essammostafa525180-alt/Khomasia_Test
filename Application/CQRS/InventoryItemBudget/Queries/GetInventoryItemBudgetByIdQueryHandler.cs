using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemBudget.Queries;

public class GetInventoryItemBudgetByIdQuery : IQuery<Result<InventoryItemBudgetDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemBudgetByIdQueryHandler : IQueryHandler<GetInventoryItemBudgetByIdQuery, Result<InventoryItemBudgetDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemBudgetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemBudgetDetailsResponse>> Handle(GetInventoryItemBudgetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemBudgetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemBudgetDetailsResponse>.Failure(Errors.InventoryItemBudgetNotFound);

        var response = entity.Adapt<InventoryItemBudgetDetailsResponse>();

        return Result<InventoryItemBudgetDetailsResponse>.Success(response);
    }
}
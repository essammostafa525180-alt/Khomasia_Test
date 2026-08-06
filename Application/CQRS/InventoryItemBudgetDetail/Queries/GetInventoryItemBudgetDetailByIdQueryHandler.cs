using Application.Abstractions;
using Mapster;

namespace Application.CQRS.InventoryItemBudgetDetail.Queries;

public class GetInventoryItemBudgetDetailByIdQuery : IQuery<Result<InventoryItemBudgetDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetInventoryItemBudgetDetailByIdQueryHandler : IQueryHandler<GetInventoryItemBudgetDetailByIdQuery, Result<InventoryItemBudgetDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInventoryItemBudgetDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InventoryItemBudgetDetailDetailsResponse>> Handle(GetInventoryItemBudgetDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemBudgetDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<InventoryItemBudgetDetailDetailsResponse>.Failure(Errors.InventoryItemBudgetDetailNotFound);

        var response = entity.Adapt<InventoryItemBudgetDetailDetailsResponse>();

        return Result<InventoryItemBudgetDetailDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryItemBudget.Commands;

public class CreateInventoryItemBudgetCommand : ICommand<Result<int>>
{
        public int? CompanyFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? LocationFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ScopeFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemBudgetCommandHandler : ICommandHandler<CreateInventoryItemBudgetCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemBudgetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemBudgetCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemBudget.Create(request.CompanyFk, request.ProjectFk, request.LocationFk, request.ServiceMainCategoryFk, request.ScopeFk, request.IsActive);

        await _unitOfWork.InventoryItemBudgetRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemBudgetNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryItemBudget.Commands;

public class UpdateInventoryItemBudgetCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? CompanyFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? LocationFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ScopeFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemBudgetCommandHandler : ICommandHandler<UpdateInventoryItemBudgetCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemBudgetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemBudgetCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemBudgetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemBudgetNotFound);

        entity.Update(request.CompanyFk, request.ProjectFk, request.LocationFk, request.ServiceMainCategoryFk, request.ScopeFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemBudgetNotUpdated);
    }
}
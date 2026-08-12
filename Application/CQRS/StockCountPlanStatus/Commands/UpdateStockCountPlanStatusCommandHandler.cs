using Application.Abstractions;

namespace Application.CQRS.StockCountPlanStatus.Commands;

public class UpdateStockCountPlanStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateStockCountPlanStatusCommandHandler : ICommandHandler<UpdateStockCountPlanStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStockCountPlanStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStockCountPlanStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StockCountPlanStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StockCountPlanStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StockCountPlanStatusNotUpdated);
    }
}
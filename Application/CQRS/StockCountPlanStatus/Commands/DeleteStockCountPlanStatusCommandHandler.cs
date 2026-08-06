using Application.Abstractions;

namespace Application.CQRS.StockCountPlanStatus.Commands;

public class DeleteStockCountPlanStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteStockCountPlanStatusCommandHandler : ICommandHandler<DeleteStockCountPlanStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStockCountPlanStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStockCountPlanStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StockCountPlanStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StockCountPlanStatusNotFound);

        _unitOfWork.StockCountPlanStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StockCountPlanStatusNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.StockCountPlanType.Commands;

public class DeleteStockCountPlanTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteStockCountPlanTypeCommandHandler : ICommandHandler<DeleteStockCountPlanTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStockCountPlanTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStockCountPlanTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StockCountPlanTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StockCountPlanTypeNotFound);

        _unitOfWork.StockCountPlanTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StockCountPlanTypeNotDeleted);
    }
}
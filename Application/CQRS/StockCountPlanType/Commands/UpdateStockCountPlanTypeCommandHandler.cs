using Application.Abstractions;

namespace Application.CQRS.StockCountPlanType.Commands;

public class UpdateStockCountPlanTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateStockCountPlanTypeCommandHandler : ICommandHandler<UpdateStockCountPlanTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStockCountPlanTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStockCountPlanTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StockCountPlanTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StockCountPlanTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StockCountPlanTypeNotUpdated);
    }
}
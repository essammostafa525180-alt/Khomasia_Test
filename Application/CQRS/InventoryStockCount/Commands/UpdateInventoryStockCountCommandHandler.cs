using Application.Abstractions;

namespace Application.CQRS.InventoryStockCount.Commands;

public class UpdateInventoryStockCountCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryStockCountCommandHandler : ICommandHandler<UpdateInventoryStockCountCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryStockCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryStockCountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountNotUpdated);
    }
}
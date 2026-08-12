using Application.Abstractions;

namespace Application.CQRS.InventoryStockCount.Commands;

public class CreateInventoryStockCountCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateInventoryStockCountCommandHandler : ICommandHandler<CreateInventoryStockCountCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryStockCountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryStockCountCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.InventoryStockCount.Create(request.IsActive);

        await _unitOfWork.InventoryStockCountRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryStockCountNotInserted);
    }
}
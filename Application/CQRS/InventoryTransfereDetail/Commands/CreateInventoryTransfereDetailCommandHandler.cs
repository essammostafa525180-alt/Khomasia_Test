using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetail.Commands;

public class CreateInventoryTransfereDetailCommand : ICommand<Result<int>>
{
        public int? InventoryTransfereFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryTransfereDetailCommandHandler : ICommandHandler<CreateInventoryTransfereDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryTransfereDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryTransfereDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryTransfereAggregate.InventoryTransfereDetail.Create(request.InventoryTransfereFk, request.InventoryItemFk, request.Quantity, request.IsActive);

        await _unitOfWork.InventoryTransfereDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryTransfereDetailNotInserted);
    }
}
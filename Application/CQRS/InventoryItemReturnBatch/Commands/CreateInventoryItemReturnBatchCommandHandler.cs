using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnBatch.Commands;

public class CreateInventoryItemReturnBatchCommand : ICommand<Result<int>>
{
        public int? ItemReturnDetailFk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public int? RwDeliveredBatchFk { get; set; }
        public string? Notes { get; set; }
        public int? BatchFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemReturnBatchCommandHandler : ICommandHandler<CreateInventoryItemReturnBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemReturnBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemReturnBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemReturnBatch.Create(request.ItemReturnDetailFk, request.ReturnedQuantity, request.ReturnReasonFk, request.RwDeliveredBatchFk, request.Notes, request.BatchFk, request.IsActive);

        await _unitOfWork.InventoryItemReturnBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemReturnBatchNotInserted);
    }
}
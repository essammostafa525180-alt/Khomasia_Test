using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnBatch.Commands;

public class UpdateInventoryItemReturnBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? ItemReturnDetailFk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public int? RwDeliveredBatchFk { get; set; }
        public string? Notes { get; set; }
        public int? BatchFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemReturnBatchCommandHandler : ICommandHandler<UpdateInventoryItemReturnBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemReturnBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemReturnBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnBatchNotFound);

        entity.Update(request.ItemReturnDetailFk, request.ReturnedQuantity, request.ReturnReasonFk, request.RwDeliveredBatchFk, request.Notes, request.BatchFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnBatchNotUpdated);
    }
}
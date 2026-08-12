using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnBatchSerial.Commands;

public class UpdateInventoryItemReturnBatchSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryItemReturnBatchFk { get; set; }
        public int? ReturnReasonFk { get; set; }
        public int? RwDelivedSerialFk { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemReturnBatchSerialCommandHandler : ICommandHandler<UpdateInventoryItemReturnBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemReturnBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemReturnBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnBatchSerialNotFound);

        entity.Update(request.InventoryItemReturnBatchFk, request.ReturnReasonFk, request.RwDelivedSerialFk, request.Notes, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnBatchSerialNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnBatchSerial.Commands;

public class CreateInventoryItemReturnBatchSerialCommand : ICommand<Result<int>>
{
        public int? InventoryItemReturnBatchFk { get; set; }
        public int? ReturnReasonFk { get; set; }
        public int? RwDelivedSerialFk { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemReturnBatchSerialCommandHandler : ICommandHandler<CreateInventoryItemReturnBatchSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemReturnBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemReturnBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemReturnBatchSerial.Create(request.InventoryItemReturnBatchFk, request.ReturnReasonFk, request.RwDelivedSerialFk, request.Notes, request.IsActive);

        await _unitOfWork.InventoryItemReturnBatchSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemReturnBatchSerialNotInserted);
    }
}
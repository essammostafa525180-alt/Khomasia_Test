using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationBatchSerial.Commands;

public class CreateInventoryItemLocationBatchSerialCommand : ICommand<Result<int>>
{
        public int? InventoryItemLocationBatchFk { get; set; }
        public string? SerialNumber { get; set; }
        public bool? IsAvailable { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemLocationBatchSerialCommandHandler : ICommandHandler<CreateInventoryItemLocationBatchSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemLocationBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemLocationBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemLocationBatchSerial.Create(request.InventoryItemLocationBatchFk, request.SerialNumber, request.IsAvailable, request.IsActive);

        await _unitOfWork.InventoryItemLocationBatchSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemLocationBatchSerialNotInserted);
    }
}
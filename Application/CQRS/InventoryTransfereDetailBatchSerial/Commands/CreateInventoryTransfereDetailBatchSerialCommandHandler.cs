using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetailBatchSerial.Commands;

public class CreateInventoryTransfereDetailBatchSerialCommand : ICommand<Result<int>>
{
        public int? InventoryTransfereDetailBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryTransfereDetailBatchSerialCommandHandler : ICommandHandler<CreateInventoryTransfereDetailBatchSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryTransfereDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryTransfereDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryTransfereAggregate.InventoryTransfereDetailBatchSerial.Create(request.InventoryTransfereDetailBatchFk, request.SerialFk, request.IsActive);

        await _unitOfWork.InventoryTransfereDetailBatchSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryTransfereDetailBatchSerialNotInserted);
    }
}
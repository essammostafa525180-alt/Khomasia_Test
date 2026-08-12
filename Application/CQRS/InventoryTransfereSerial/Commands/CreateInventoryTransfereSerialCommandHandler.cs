using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereSerial.Commands;

public class CreateInventoryTransfereSerialCommand : ICommand<Result<int>>
{
        public int? InventoryTransfereFk { get; set; }
        public int? InventoryTransfereDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryTransfereSerialCommandHandler : ICommandHandler<CreateInventoryTransfereSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryTransfereSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryTransfereSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryTransfereAggregate.InventoryTransfereSerial.Create(request.InventoryTransfereFk, request.InventoryTransfereDetailFk, request.InventoryItemSerialFk, request.IsActive);

        await _unitOfWork.InventoryTransfereSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryTransfereSerialNotInserted);
    }
}
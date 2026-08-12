using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnSerial.Commands;

public class CreateInventoryItemReturnSerialCommand : ICommand<Result<int>>
{
        public int? InventoryItemReturnFk { get; set; }
        public int? InventoryItemReturnDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemReturnSerialCommandHandler : ICommandHandler<CreateInventoryItemReturnSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemReturnSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemReturnSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemReturnSerial.Create(request.InventoryItemReturnFk, request.InventoryItemReturnDetailFk, request.InventoryItemSerialFk, request.IsActive);

        await _unitOfWork.InventoryItemReturnSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemReturnSerialNotInserted);
    }
}
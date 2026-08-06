using Application.Abstractions;

namespace Application.CQRS.InventoryItemSerial.Commands;

public class CreateInventoryItemSerialCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemSerialCommandHandler : ICommandHandler<CreateInventoryItemSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemSerial.Create(request.IsActive);

        await _unitOfWork.InventoryItemSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemSerialNotInserted);
    }
}
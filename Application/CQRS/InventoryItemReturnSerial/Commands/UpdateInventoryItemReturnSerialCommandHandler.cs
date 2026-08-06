using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnSerial.Commands;

public class UpdateInventoryItemReturnSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryItemReturnFk { get; set; }
        public int? InventoryItemReturnDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemReturnSerialCommandHandler : ICommandHandler<UpdateInventoryItemReturnSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemReturnSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemReturnSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnSerialNotFound);

        entity.Update(request.InventoryItemReturnFk, request.InventoryItemReturnDetailFk, request.InventoryItemSerialFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnSerialNotUpdated);
    }
}
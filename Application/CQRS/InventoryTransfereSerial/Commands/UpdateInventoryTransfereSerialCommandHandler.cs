using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereSerial.Commands;

public class UpdateInventoryTransfereSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryTransfereFk { get; set; }
        public int? InventoryTransfereDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryTransfereSerialCommandHandler : ICommandHandler<UpdateInventoryTransfereSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryTransfereSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryTransfereSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereSerialNotFound);

        entity.Update(request.InventoryTransfereFk, request.InventoryTransfereDetailFk, request.InventoryItemSerialFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereSerialNotUpdated);
    }
}
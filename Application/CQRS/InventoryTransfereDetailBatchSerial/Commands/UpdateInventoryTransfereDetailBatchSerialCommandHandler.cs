using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetailBatchSerial.Commands;

public class UpdateInventoryTransfereDetailBatchSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryTransfereDetailBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryTransfereDetailBatchSerialCommandHandler : ICommandHandler<UpdateInventoryTransfereDetailBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryTransfereDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryTransfereDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereDetailBatchSerialNotFound);

        entity.Update(request.InventoryTransfereDetailBatchFk, request.SerialFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereDetailBatchSerialNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationBatchSerial.Commands;

public class UpdateInventoryItemLocationBatchSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryItemLocationBatchFk { get; set; }
        public string? SerialNumber { get; set; }
        public bool? IsAvailable { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemLocationBatchSerialCommandHandler : ICommandHandler<UpdateInventoryItemLocationBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemLocationBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemLocationBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemLocationBatchSerialNotFound);

        entity.Update(request.InventoryItemLocationBatchFk, request.SerialNumber, request.IsAvailable, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemLocationBatchSerialNotUpdated);
    }
}
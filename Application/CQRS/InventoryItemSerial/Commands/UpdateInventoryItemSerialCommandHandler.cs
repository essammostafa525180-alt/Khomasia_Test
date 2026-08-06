using Application.Abstractions;

namespace Application.CQRS.InventoryItemSerial.Commands;

public class UpdateInventoryItemSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemSerialCommandHandler : ICommandHandler<UpdateInventoryItemSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemSerialNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemSerialNotUpdated);
    }
}
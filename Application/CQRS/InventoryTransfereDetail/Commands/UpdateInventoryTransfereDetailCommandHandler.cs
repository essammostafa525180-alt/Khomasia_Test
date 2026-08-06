using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetail.Commands;

public class UpdateInventoryTransfereDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryTransfereFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryTransfereDetailCommandHandler : ICommandHandler<UpdateInventoryTransfereDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryTransfereDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryTransfereDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereDetailNotFound);

        entity.Update(request.InventoryTransfereFk, request.InventoryItemFk, request.Quantity, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereDetailNotUpdated);
    }
}
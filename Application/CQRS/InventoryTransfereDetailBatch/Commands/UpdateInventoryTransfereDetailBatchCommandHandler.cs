using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetailBatch.Commands;

public class UpdateInventoryTransfereDetailBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryTransfereDetailFk { get; set; }
        public int? BatchFk { get; set; }
        public string? NewBatchNumber { get; set; }
        public decimal? Qunatity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ShelfFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryTransfereDetailBatchCommandHandler : ICommandHandler<UpdateInventoryTransfereDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryTransfereDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryTransfereDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereDetailBatchNotFound);

        entity.Update(request.InventoryTransfereDetailFk, request.BatchFk, request.NewBatchNumber, request.Qunatity, request.ExpiryDate, request.ShelfFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereDetailBatchNotUpdated);
    }
}
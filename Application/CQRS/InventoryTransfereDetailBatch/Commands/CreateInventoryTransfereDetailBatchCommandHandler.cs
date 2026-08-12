using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetailBatch.Commands;

public class CreateInventoryTransfereDetailBatchCommand : ICommand<Result<int>>
{
        public int? InventoryTransfereDetailFk { get; set; }
        public int? BatchFk { get; set; }
        public string? NewBatchNumber { get; set; }
        public decimal? Qunatity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ShelfFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryTransfereDetailBatchCommandHandler : ICommandHandler<CreateInventoryTransfereDetailBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryTransfereDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryTransfereDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryTransfereAggregate.InventoryTransfereDetailBatch.Create(request.InventoryTransfereDetailFk, request.BatchFk, request.NewBatchNumber, request.Qunatity, request.ExpiryDate, request.ShelfFk, request.IsActive);

        await _unitOfWork.InventoryTransfereDetailBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryTransfereDetailBatchNotInserted);
    }
}
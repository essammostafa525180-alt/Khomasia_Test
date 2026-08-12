using Application.Abstractions;

namespace Application.CQRS.RwDeliveredBatch.Commands;

public class CreateRwDeliveredBatchCommand : ICommand<Result<int>>
{
        public int? RequestWdfk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public decimal? DeliveredQuantity { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public int? BatchFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRwDeliveredBatchCommandHandler : ICommandHandler<CreateRwDeliveredBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRwDeliveredBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRwDeliveredBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.RequestAggregate.RwDeliveredBatch.Create(request.RequestWdfk, request.ReturnedQuantity, request.DeliveredQuantity, request.DeliveredDate, request.BatchFk, request.Axsynced, request.IsActive);

        await _unitOfWork.RwDeliveredBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RwDeliveredBatchNotInserted);
    }
}
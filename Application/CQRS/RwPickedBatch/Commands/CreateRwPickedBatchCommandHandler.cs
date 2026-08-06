using Application.Abstractions;

namespace Application.CQRS.RwPickedBatch.Commands;

public class CreateRwPickedBatchCommand : ICommand<Result<int>>
{
        public int? RequestWdfk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public decimal? PickedQuantity { get; set; }
        public DateTime? PickedDate { get; set; }
        public int? BatchFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateRwPickedBatchCommandHandler : ICommandHandler<CreateRwPickedBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRwPickedBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateRwPickedBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.RequestAggregate.RwPickedBatch.Create(request.RequestWdfk, request.ReturnedQuantity, request.PickedQuantity, request.PickedDate, request.BatchFk, request.Axsynced, request.IsActive);

        await _unitOfWork.RwPickedBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.RwPickedBatchNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.RwDeliveredBatch.Commands;

public class UpdateRwDeliveredBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RequestWdfk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public decimal? DeliveredQuantity { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public int? BatchFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRwDeliveredBatchCommandHandler : ICommandHandler<UpdateRwDeliveredBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRwDeliveredBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRwDeliveredBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwDeliveredBatchNotFound);

        entity.Update(request.RequestWdfk, request.ReturnedQuantity, request.DeliveredQuantity, request.DeliveredDate, request.BatchFk, request.Axsynced, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwDeliveredBatchNotUpdated);
    }
}
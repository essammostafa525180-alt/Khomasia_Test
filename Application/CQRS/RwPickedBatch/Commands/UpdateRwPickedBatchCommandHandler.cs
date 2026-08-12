using Application.Abstractions;

namespace Application.CQRS.RwPickedBatch.Commands;

public class UpdateRwPickedBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RequestWdfk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public decimal? PickedQuantity { get; set; }
        public DateTime? PickedDate { get; set; }
        public int? BatchFk { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateRwPickedBatchCommandHandler : ICommandHandler<UpdateRwPickedBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRwPickedBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRwPickedBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwPickedBatchNotFound);

        entity.Update(request.RequestWdfk, request.ReturnedQuantity, request.PickedQuantity, request.PickedDate, request.BatchFk, request.Axsynced, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwPickedBatchNotUpdated);
    }
}
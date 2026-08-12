using Application.Abstractions;

namespace Application.CQRS.RwDeliveredBatch.Commands;

public class DeleteRwDeliveredBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRwDeliveredBatchCommandHandler : ICommandHandler<DeleteRwDeliveredBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRwDeliveredBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRwDeliveredBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwDeliveredBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwDeliveredBatchNotFound);

        _unitOfWork.RwDeliveredBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwDeliveredBatchNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.RwPickedBatch.Commands;

public class DeleteRwPickedBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRwPickedBatchCommandHandler : ICommandHandler<DeleteRwPickedBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRwPickedBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRwPickedBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwPickedBatchNotFound);

        _unitOfWork.RwPickedBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwPickedBatchNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.WorkerType.Commands;

public class DeleteWorkerTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteWorkerTypeCommandHandler : ICommandHandler<DeleteWorkerTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWorkerTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteWorkerTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WorkerTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WorkerTypeNotFound);

        _unitOfWork.WorkerTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WorkerTypeNotDeleted);
    }
}
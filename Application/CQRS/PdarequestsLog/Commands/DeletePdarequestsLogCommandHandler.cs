using Application.Abstractions;

namespace Application.CQRS.PdarequestsLog.Commands;

public class DeletePdarequestsLogCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePdarequestsLogCommandHandler : ICommandHandler<DeletePdarequestsLogCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePdarequestsLogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePdarequestsLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdarequestsLogRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PdarequestsLogNotFound);

        _unitOfWork.PdarequestsLogRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PdarequestsLogNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.State.Commands;

public class DeleteStateCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteStateCommandHandler : ICommandHandler<DeleteStateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StateNotFound);

        _unitOfWork.StateRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StateNotDeleted);
    }
}
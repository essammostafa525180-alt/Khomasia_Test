using Application.Abstractions;

namespace Application.CQRS.Project.Commands;

public class DeleteProjectCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ProjectNotFound);

        _unitOfWork.ProjectRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ProjectNotDeleted);
    }
}
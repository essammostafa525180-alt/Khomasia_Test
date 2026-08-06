using Application.Abstractions;

namespace Application.CQRS.EngineSize.Commands;

public class DeleteEngineSizeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteEngineSizeCommandHandler : ICommandHandler<DeleteEngineSizeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEngineSizeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteEngineSizeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EngineSizeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.EngineSizeNotFound);

        _unitOfWork.EngineSizeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.EngineSizeNotDeleted);
    }
}
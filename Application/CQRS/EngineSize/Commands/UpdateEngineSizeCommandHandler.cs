using Application.Abstractions;

namespace Application.CQRS.EngineSize.Commands;

public class UpdateEngineSizeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateEngineSizeCommandHandler : ICommandHandler<UpdateEngineSizeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEngineSizeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateEngineSizeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EngineSizeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.EngineSizeNotFound);

        entity.Update(request.Name, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.EngineSizeNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.EngineSize.Commands;

public class CreateEngineSizeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateEngineSizeCommandHandler : ICommandHandler<CreateEngineSizeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEngineSizeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateEngineSizeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.EngineSize.Create(request.Name, request.IsActive);

        await _unitOfWork.EngineSizeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.EngineSizeNotInserted);
    }
}
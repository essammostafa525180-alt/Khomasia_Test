using Application.Abstractions;

namespace Application.CQRS.Scope.Commands;

public class DeleteScopeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteScopeCommandHandler : ICommandHandler<DeleteScopeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteScopeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteScopeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ScopeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ScopeNotFound);

        _unitOfWork.ScopeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ScopeNotDeleted);
    }
}
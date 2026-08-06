using Application.Abstractions;

namespace Application.CQRS.SecModule.Commands;

public class DeleteSecModuleCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecModuleCommandHandler : ICommandHandler<DeleteSecModuleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecModuleNotFound);

        _unitOfWork.SecModuleRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecModuleNotDeleted);
    }
}
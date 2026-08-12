using Application.Abstractions;

namespace Application.CQRS.SecUserModule.Commands;

public class DeleteSecUserModuleCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecUserModuleCommandHandler : ICommandHandler<DeleteSecUserModuleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecUserModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecUserModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserModuleNotFound);

        _unitOfWork.SecUserModuleRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserModuleNotDeleted);
    }
}
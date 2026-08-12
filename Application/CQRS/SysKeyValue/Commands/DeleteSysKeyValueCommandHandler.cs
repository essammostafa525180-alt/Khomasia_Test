using Application.Abstractions;

namespace Application.CQRS.SysKeyValue.Commands;

public class DeleteSysKeyValueCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSysKeyValueCommandHandler : ICommandHandler<DeleteSysKeyValueCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSysKeyValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSysKeyValueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SysKeyValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SysKeyValueNotFound);

        _unitOfWork.SysKeyValueRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SysKeyValueNotDeleted);
    }
}
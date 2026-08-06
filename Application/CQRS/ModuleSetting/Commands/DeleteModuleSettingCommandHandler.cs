using Application.Abstractions;

namespace Application.CQRS.ModuleSetting.Commands;

public class DeleteModuleSettingCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteModuleSettingCommandHandler : ICommandHandler<DeleteModuleSettingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteModuleSettingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteModuleSettingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ModuleSettingRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ModuleSettingNotFound);

        _unitOfWork.ModuleSettingRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ModuleSettingNotDeleted);
    }
}
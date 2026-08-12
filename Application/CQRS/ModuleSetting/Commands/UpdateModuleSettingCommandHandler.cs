using Application.Abstractions;

namespace Application.CQRS.ModuleSetting.Commands;

public class UpdateModuleSettingCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? SettingName { get; set; }
        public string? SettingValue { get; set; }
        public string? Measure { get; set; }
        public string? MeasureAr { get; set; }
        public int? DataType { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateModuleSettingCommandHandler : ICommandHandler<UpdateModuleSettingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateModuleSettingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateModuleSettingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ModuleSettingRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ModuleSettingNotFound);

        entity.Update(request.SettingName, request.SettingValue, request.Measure, request.MeasureAr, request.DataType, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ModuleSettingNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.ModuleSetting.Commands;

public class CreateModuleSettingCommand : ICommand<Result<int>>
{
        public string? SettingName { get; set; }
        public string? SettingValue { get; set; }
        public string? Measure { get; set; }
        public string? MeasureAr { get; set; }
        public int? DataType { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateModuleSettingCommandHandler : ICommandHandler<CreateModuleSettingCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateModuleSettingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateModuleSettingCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ModuleSetting.Create(request.SettingName, request.SettingValue, request.Measure, request.MeasureAr, request.DataType, request.IsActive);

        await _unitOfWork.ModuleSettingRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ModuleSettingNotInserted);
    }
}
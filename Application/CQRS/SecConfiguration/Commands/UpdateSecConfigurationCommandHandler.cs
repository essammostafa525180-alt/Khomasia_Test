using Application.Abstractions;

namespace Application.CQRS.SecConfiguration.Commands;

public class UpdateSecConfigurationCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecConfigurationCommandHandler : ICommandHandler<UpdateSecConfigurationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecConfigurationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecConfigurationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecConfigurationNotFound);

        entity.Update(request.Key, request.Value, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecConfigurationNotUpdated);
    }
}
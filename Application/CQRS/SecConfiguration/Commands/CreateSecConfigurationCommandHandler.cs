using Application.Abstractions;

namespace Application.CQRS.SecConfiguration.Commands;

public class CreateSecConfigurationCommand : ICommand<Result<int>>
{
        public string? Key { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecConfigurationCommandHandler : ICommandHandler<CreateSecConfigurationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecConfigurationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SecConfiguration.Create(request.Key, request.Value, request.IsActive);

        await _unitOfWork.SecConfigurationRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecConfigurationNotInserted);
    }
}
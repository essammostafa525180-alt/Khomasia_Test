using Application.Abstractions;

namespace Application.CQRS.SecConfiguration.Commands;

public class DeleteSecConfigurationCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecConfigurationCommandHandler : ICommandHandler<DeleteSecConfigurationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecConfigurationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecConfigurationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecConfigurationNotFound);

        _unitOfWork.SecConfigurationRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecConfigurationNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.BatteryType.Commands;

public class DeleteBatteryTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteBatteryTypeCommandHandler : ICommandHandler<DeleteBatteryTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBatteryTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteBatteryTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BatteryTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.BatteryTypeNotFound);

        _unitOfWork.BatteryTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.BatteryTypeNotDeleted);
    }
}
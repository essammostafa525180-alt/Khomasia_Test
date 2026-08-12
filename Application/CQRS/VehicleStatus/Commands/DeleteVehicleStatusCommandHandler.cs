using Application.Abstractions;

namespace Application.CQRS.VehicleStatus.Commands;

public class DeleteVehicleStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVehicleStatusCommandHandler : ICommandHandler<DeleteVehicleStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleStatusNotFound);

        _unitOfWork.VehicleStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleStatusNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.Vehicle.Commands;

public class DeleteVehicleCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVehicleCommandHandler : ICommandHandler<DeleteVehicleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleNotFound);

        _unitOfWork.VehicleRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VehicleColor.Commands;

public class DeleteVehicleColorCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVehicleColorCommandHandler : ICommandHandler<DeleteVehicleColorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleColorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleColorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleColorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleColorNotFound);

        _unitOfWork.VehicleColorRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleColorNotDeleted);
    }
}
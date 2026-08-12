using Application.Abstractions;

namespace Application.CQRS.VehicleModel.Commands;

public class DeleteVehicleModelCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVehicleModelCommandHandler : ICommandHandler<DeleteVehicleModelCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleModelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleModelNotFound);

        _unitOfWork.VehicleModelRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleModelNotDeleted);
    }
}
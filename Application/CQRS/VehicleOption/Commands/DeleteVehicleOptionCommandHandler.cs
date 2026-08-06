using Application.Abstractions;

namespace Application.CQRS.VehicleOption.Commands;

public class DeleteVehicleOptionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVehicleOptionCommandHandler : ICommandHandler<DeleteVehicleOptionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleOptionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleOptionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleOptionNotFound);

        _unitOfWork.VehicleOptionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleOptionNotDeleted);
    }
}
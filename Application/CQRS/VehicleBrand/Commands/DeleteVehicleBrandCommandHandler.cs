using Application.Abstractions;

namespace Application.CQRS.VehicleBrand.Commands;

public class DeleteVehicleBrandCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVehicleBrandCommandHandler : ICommandHandler<DeleteVehicleBrandCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleBrandRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleBrandNotFound);

        _unitOfWork.VehicleBrandRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleBrandNotDeleted);
    }
}
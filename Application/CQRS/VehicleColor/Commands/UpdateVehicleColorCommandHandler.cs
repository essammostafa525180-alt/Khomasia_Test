using Application.Abstractions;

namespace Application.CQRS.VehicleColor.Commands;

public class UpdateVehicleColorCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVehicleColorCommandHandler : ICommandHandler<UpdateVehicleColorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleColorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVehicleColorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleColorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleColorNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleColorNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VehicleStatus.Commands;

public class UpdateVehicleStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVehicleStatusCommandHandler : ICommandHandler<UpdateVehicleStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVehicleStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleStatusNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.Description, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleStatusNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VehicleModel.Commands;

public class UpdateVehicleModelCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? VehicleBrandFk { get; set; }
        public int? YearFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVehicleModelCommandHandler : ICommandHandler<UpdateVehicleModelCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVehicleModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleModelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleModelNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.VehicleBrandFk, request.YearFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleModelNotUpdated);
    }
}
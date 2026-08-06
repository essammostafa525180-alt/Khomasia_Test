using Application.Abstractions;

namespace Application.CQRS.VehicleType.Commands;

public class UpdateVehicleTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public decimal? InteriorVolume { get; set; }
        public int? EquipmentTypeFk { get; set; }
        public string? Description { get; set; }
        public decimal? InteriorLenght { get; set; }
        public decimal? ExteriorLenght { get; set; }
        public decimal? InteriorWidth { get; set; }
        public decimal? ExteriorWidth { get; set; }
        public decimal? InteriorHeight { get; set; }
        public decimal? ExteriorHeight { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? MaxGrossWeight { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVehicleTypeCommandHandler : ICommandHandler<UpdateVehicleTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleTypeNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.InteriorVolume, request.EquipmentTypeFk, request.Description, request.InteriorLenght, request.ExteriorLenght, request.InteriorWidth, request.ExteriorWidth, request.InteriorHeight, request.ExteriorHeight, request.TareWeight, request.MaxGrossWeight, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleTypeNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VehicleType.Commands;

public class CreateVehicleTypeCommand : ICommand<Result<int>>
{
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
internal class CreateVehicleTypeCommandHandler : ICommandHandler<CreateVehicleTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VehicleType.Create(request.Code, request.Name, request.NameAr, request.InteriorVolume, request.EquipmentTypeFk, request.Description, request.InteriorLenght, request.ExteriorLenght, request.InteriorWidth, request.ExteriorWidth, request.InteriorHeight, request.ExteriorHeight, request.TareWeight, request.MaxGrossWeight, request.IsActive);

        await _unitOfWork.VehicleTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VehicleTypeNotInserted);
    }
}
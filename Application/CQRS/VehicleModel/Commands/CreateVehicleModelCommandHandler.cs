using Application.Abstractions;

namespace Application.CQRS.VehicleModel.Commands;

public class CreateVehicleModelCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? VehicleBrandFk { get; set; }
        public int? YearFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVehicleModelCommandHandler : ICommandHandler<CreateVehicleModelCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVehicleModelCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VehicleModel.Create(request.Code, request.Name, request.NameAr, request.VehicleBrandFk, request.YearFk, request.IsActive);

        await _unitOfWork.VehicleModelRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VehicleModelNotInserted);
    }
}
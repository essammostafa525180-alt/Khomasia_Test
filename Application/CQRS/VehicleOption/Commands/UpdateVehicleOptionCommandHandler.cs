using Application.Abstractions;

namespace Application.CQRS.VehicleOption.Commands;

public class UpdateVehicleOptionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVehicleOptionCommandHandler : ICommandHandler<UpdateVehicleOptionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleOptionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVehicleOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleOptionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleOptionNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleOptionNotUpdated);
    }
}
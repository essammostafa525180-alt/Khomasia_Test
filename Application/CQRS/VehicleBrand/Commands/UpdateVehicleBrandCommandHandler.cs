using Application.Abstractions;

namespace Application.CQRS.VehicleBrand.Commands;

public class UpdateVehicleBrandCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVehicleBrandCommandHandler : ICommandHandler<UpdateVehicleBrandCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVehicleBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleBrandRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VehicleBrandNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VehicleBrandNotUpdated);
    }
}
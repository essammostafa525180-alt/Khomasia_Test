using Application.Abstractions;

namespace Application.CQRS.VehicleColor.Commands;

public class CreateVehicleColorCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVehicleColorCommandHandler : ICommandHandler<CreateVehicleColorCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleColorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVehicleColorCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VehicleColor.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VehicleColorRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VehicleColorNotInserted);
    }
}
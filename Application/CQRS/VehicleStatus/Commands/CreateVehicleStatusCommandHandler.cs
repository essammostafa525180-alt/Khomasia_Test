using Application.Abstractions;

namespace Application.CQRS.VehicleStatus.Commands;

public class CreateVehicleStatusCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVehicleStatusCommandHandler : ICommandHandler<CreateVehicleStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVehicleStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VehicleStatus.Create(request.Code, request.Name, request.NameAr, request.Description, request.IsActive);

        await _unitOfWork.VehicleStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VehicleStatusNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VehicleOption.Commands;

public class CreateVehicleOptionCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVehicleOptionCommandHandler : ICommandHandler<CreateVehicleOptionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleOptionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVehicleOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VehicleOption.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VehicleOptionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VehicleOptionNotInserted);
    }
}
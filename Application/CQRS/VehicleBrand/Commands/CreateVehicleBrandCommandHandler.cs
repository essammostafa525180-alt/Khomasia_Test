using Application.Abstractions;

namespace Application.CQRS.VehicleBrand.Commands;

public class CreateVehicleBrandCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVehicleBrandCommandHandler : ICommandHandler<CreateVehicleBrandCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVehicleBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VehicleBrand.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VehicleBrandRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VehicleBrandNotInserted);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Vehicle.Queries;

public class GetVehicleByIdQuery : IQuery<Result<VehicleDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVehicleByIdQueryHandler : IQueryHandler<GetVehicleByIdQuery, Result<VehicleDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VehicleDetailsResponse>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VehicleDetailsResponse>.Failure(Errors.VehicleNotFound);

        var response = entity.Adapt<VehicleDetailsResponse>();

        return Result<VehicleDetailsResponse>.Success(response);
    }
}
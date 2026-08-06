using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VehicleColor.Queries;

public class GetVehicleColorByIdQuery : IQuery<Result<VehicleColorDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVehicleColorByIdQueryHandler : IQueryHandler<GetVehicleColorByIdQuery, Result<VehicleColorDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleColorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VehicleColorDetailsResponse>> Handle(GetVehicleColorByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleColorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VehicleColorDetailsResponse>.Failure(Errors.VehicleColorNotFound);

        var response = entity.Adapt<VehicleColorDetailsResponse>();

        return Result<VehicleColorDetailsResponse>.Success(response);
    }
}
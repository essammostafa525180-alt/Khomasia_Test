using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VehicleStatus.Queries;

public class GetVehicleStatusByIdQuery : IQuery<Result<VehicleStatusDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVehicleStatusByIdQueryHandler : IQueryHandler<GetVehicleStatusByIdQuery, Result<VehicleStatusDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleStatusByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VehicleStatusDetailsResponse>> Handle(GetVehicleStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VehicleStatusDetailsResponse>.Failure(Errors.VehicleStatusNotFound);

        var response = entity.Adapt<VehicleStatusDetailsResponse>();

        return Result<VehicleStatusDetailsResponse>.Success(response);
    }
}
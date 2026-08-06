using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VehicleModel.Queries;

public class GetVehicleModelByIdQuery : IQuery<Result<VehicleModelDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVehicleModelByIdQueryHandler : IQueryHandler<GetVehicleModelByIdQuery, Result<VehicleModelDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleModelByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VehicleModelDetailsResponse>> Handle(GetVehicleModelByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleModelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VehicleModelDetailsResponse>.Failure(Errors.VehicleModelNotFound);

        var response = entity.Adapt<VehicleModelDetailsResponse>();

        return Result<VehicleModelDetailsResponse>.Success(response);
    }
}
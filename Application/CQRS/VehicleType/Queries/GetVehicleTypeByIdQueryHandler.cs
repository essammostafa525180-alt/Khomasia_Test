using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VehicleType.Queries;

public class GetVehicleTypeByIdQuery : IQuery<Result<VehicleTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVehicleTypeByIdQueryHandler : IQueryHandler<GetVehicleTypeByIdQuery, Result<VehicleTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VehicleTypeDetailsResponse>> Handle(GetVehicleTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VehicleTypeDetailsResponse>.Failure(Errors.VehicleTypeNotFound);

        var response = entity.Adapt<VehicleTypeDetailsResponse>();

        return Result<VehicleTypeDetailsResponse>.Success(response);
    }
}
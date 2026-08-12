using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VehicleBrand.Queries;

public class GetVehicleBrandByIdQuery : IQuery<Result<VehicleBrandDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVehicleBrandByIdQueryHandler : IQueryHandler<GetVehicleBrandByIdQuery, Result<VehicleBrandDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleBrandByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VehicleBrandDetailsResponse>> Handle(GetVehicleBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleBrandRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VehicleBrandDetailsResponse>.Failure(Errors.VehicleBrandNotFound);

        var response = entity.Adapt<VehicleBrandDetailsResponse>();

        return Result<VehicleBrandDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VehicleOption.Queries;

public class GetVehicleOptionByIdQuery : IQuery<Result<VehicleOptionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVehicleOptionByIdQueryHandler : IQueryHandler<GetVehicleOptionByIdQuery, Result<VehicleOptionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleOptionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VehicleOptionDetailsResponse>> Handle(GetVehicleOptionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VehicleOptionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VehicleOptionDetailsResponse>.Failure(Errors.VehicleOptionNotFound);

        var response = entity.Adapt<VehicleOptionDetailsResponse>();

        return Result<VehicleOptionDetailsResponse>.Success(response);
    }
}
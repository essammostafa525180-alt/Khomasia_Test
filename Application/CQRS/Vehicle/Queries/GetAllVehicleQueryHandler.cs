using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Vehicle.Queries;

public class GetAllVehicleQuery
: IQuery<Result<PagingSortingFiltering<VehicleDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVehicleQueryHandler :
    IQueryHandler<GetAllVehicleQuery,
        Result<PagingSortingFiltering<VehicleDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehicleQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VehicleDetailsResponse>>> Handle(
        GetAllVehicleQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VehicleRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VehicleDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VehicleDetailsResponse>>.Success(result);
    }
}
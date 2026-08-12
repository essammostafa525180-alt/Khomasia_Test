using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VehicleColor.Queries;

public class GetAllVehicleColorQuery
: IQuery<Result<PagingSortingFiltering<VehicleColorDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVehicleColorQueryHandler :
    IQueryHandler<GetAllVehicleColorQuery,
        Result<PagingSortingFiltering<VehicleColorDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehicleColorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VehicleColorDetailsResponse>>> Handle(
        GetAllVehicleColorQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VehicleColorRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VehicleColorDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VehicleColorDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VehicleBrand.Queries;

public class GetAllVehicleBrandQuery
: IQuery<Result<PagingSortingFiltering<VehicleBrandDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVehicleBrandQueryHandler :
    IQueryHandler<GetAllVehicleBrandQuery,
        Result<PagingSortingFiltering<VehicleBrandDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehicleBrandQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VehicleBrandDetailsResponse>>> Handle(
        GetAllVehicleBrandQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VehicleBrandRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VehicleBrandDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VehicleBrandDetailsResponse>>.Success(result);
    }
}
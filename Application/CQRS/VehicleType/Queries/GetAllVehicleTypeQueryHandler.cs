using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VehicleType.Queries;

public class GetAllVehicleTypeQuery
: IQuery<Result<PagingSortingFiltering<VehicleTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVehicleTypeQueryHandler :
    IQueryHandler<GetAllVehicleTypeQuery,
        Result<PagingSortingFiltering<VehicleTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehicleTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VehicleTypeDetailsResponse>>> Handle(
        GetAllVehicleTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VehicleTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VehicleTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VehicleTypeDetailsResponse>>.Success(result);
    }
}
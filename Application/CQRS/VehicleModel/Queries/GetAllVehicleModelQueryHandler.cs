using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VehicleModel.Queries;

public class GetAllVehicleModelQuery
: IQuery<Result<PagingSortingFiltering<VehicleModelDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVehicleModelQueryHandler :
    IQueryHandler<GetAllVehicleModelQuery,
        Result<PagingSortingFiltering<VehicleModelDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehicleModelQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VehicleModelDetailsResponse>>> Handle(
        GetAllVehicleModelQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VehicleModelRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VehicleModelDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VehicleModelDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VehicleStatus.Queries;

public class GetAllVehicleStatusQuery
: IQuery<Result<PagingSortingFiltering<VehicleStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVehicleStatusQueryHandler :
    IQueryHandler<GetAllVehicleStatusQuery,
        Result<PagingSortingFiltering<VehicleStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehicleStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VehicleStatusDetailsResponse>>> Handle(
        GetAllVehicleStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VehicleStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VehicleStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VehicleStatusDetailsResponse>>.Success(result);
    }
}
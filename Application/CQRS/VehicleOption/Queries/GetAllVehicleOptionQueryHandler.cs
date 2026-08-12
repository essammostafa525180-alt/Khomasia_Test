using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VehicleOption.Queries;

public class GetAllVehicleOptionQuery
: IQuery<Result<PagingSortingFiltering<VehicleOptionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVehicleOptionQueryHandler :
    IQueryHandler<GetAllVehicleOptionQuery,
        Result<PagingSortingFiltering<VehicleOptionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehicleOptionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VehicleOptionDetailsResponse>>> Handle(
        GetAllVehicleOptionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VehicleOptionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VehicleOptionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VehicleOptionDetailsResponse>>.Success(result);
    }
}
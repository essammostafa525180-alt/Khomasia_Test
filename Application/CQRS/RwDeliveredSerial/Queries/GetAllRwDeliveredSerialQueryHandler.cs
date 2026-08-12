using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RwDeliveredSerial.Queries;

public class GetAllRwDeliveredSerialQuery
: IQuery<Result<PagingSortingFiltering<RwDeliveredSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRwDeliveredSerialQueryHandler :
    IQueryHandler<GetAllRwDeliveredSerialQuery,
        Result<PagingSortingFiltering<RwDeliveredSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRwDeliveredSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RwDeliveredSerialDetailsResponse>>> Handle(
        GetAllRwDeliveredSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RwDeliveredSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RwDeliveredSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RwDeliveredSerialDetailsResponse>>.Success(result);
    }
}
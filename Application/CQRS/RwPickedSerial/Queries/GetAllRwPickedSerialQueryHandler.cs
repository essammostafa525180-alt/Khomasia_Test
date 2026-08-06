using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RwPickedSerial.Queries;

public class GetAllRwPickedSerialQuery
: IQuery<Result<PagingSortingFiltering<RwPickedSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRwPickedSerialQueryHandler :
    IQueryHandler<GetAllRwPickedSerialQuery,
        Result<PagingSortingFiltering<RwPickedSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRwPickedSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RwPickedSerialDetailsResponse>>> Handle(
        GetAllRwPickedSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RwPickedSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RwPickedSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RwPickedSerialDetailsResponse>>.Success(result);
    }
}
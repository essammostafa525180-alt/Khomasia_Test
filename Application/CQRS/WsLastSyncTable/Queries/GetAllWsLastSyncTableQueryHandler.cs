using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.WsLastSyncTable.Queries;

public class GetAllWsLastSyncTableQuery
: IQuery<Result<PagingSortingFiltering<WsLastSyncTableDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllWsLastSyncTableQueryHandler :
    IQueryHandler<GetAllWsLastSyncTableQuery,
        Result<PagingSortingFiltering<WsLastSyncTableDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWsLastSyncTableQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<WsLastSyncTableDetailsResponse>>> Handle(
        GetAllWsLastSyncTableQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.WsLastSyncTableRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<WsLastSyncTableDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<WsLastSyncTableDetailsResponse>>.Success(result);
    }
}
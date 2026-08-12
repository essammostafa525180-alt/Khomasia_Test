using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Rack.Queries;

public class GetAllRackQuery
: IQuery<Result<PagingSortingFiltering<RackDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRackQueryHandler :
    IQueryHandler<GetAllRackQuery,
        Result<PagingSortingFiltering<RackDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRackQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RackDetailsResponse>>> Handle(
        GetAllRackQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RackRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RackDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RackDetailsResponse>>.Success(result);
    }
}
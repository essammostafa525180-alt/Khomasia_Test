using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PdarequestsLog.Queries;

public class GetAllPdarequestsLogQuery
: IQuery<Result<PagingSortingFiltering<PdarequestsLogDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPdarequestsLogQueryHandler :
    IQueryHandler<GetAllPdarequestsLogQuery,
        Result<PagingSortingFiltering<PdarequestsLogDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPdarequestsLogQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PdarequestsLogDetailsResponse>>> Handle(
        GetAllPdarequestsLogQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PdarequestsLogRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PdarequestsLogDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PdarequestsLogDetailsResponse>>.Success(result);
    }
}
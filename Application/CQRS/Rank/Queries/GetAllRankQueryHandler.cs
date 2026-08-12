using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Rank.Queries;

public class GetAllRankQuery
: IQuery<Result<PagingSortingFiltering<RankDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRankQueryHandler :
    IQueryHandler<GetAllRankQuery,
        Result<PagingSortingFiltering<RankDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRankQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RankDetailsResponse>>> Handle(
        GetAllRankQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RankRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RankDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RankDetailsResponse>>.Success(result);
    }
}
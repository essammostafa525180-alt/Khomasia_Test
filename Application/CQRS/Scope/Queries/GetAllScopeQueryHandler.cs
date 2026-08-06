using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Scope.Queries;

public class GetAllScopeQuery
: IQuery<Result<PagingSortingFiltering<ScopeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllScopeQueryHandler :
    IQueryHandler<GetAllScopeQuery,
        Result<PagingSortingFiltering<ScopeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllScopeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ScopeDetailsResponse>>> Handle(
        GetAllScopeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ScopeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ScopeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ScopeDetailsResponse>>.Success(result);
    }
}
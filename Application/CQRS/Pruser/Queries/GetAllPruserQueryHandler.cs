using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Pruser.Queries;

public class GetAllPruserQuery
: IQuery<Result<PagingSortingFiltering<PruserDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPruserQueryHandler :
    IQueryHandler<GetAllPruserQuery,
        Result<PagingSortingFiltering<PruserDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPruserQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PruserDetailsResponse>>> Handle(
        GetAllPruserQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PruserRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PruserDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PruserDetailsResponse>>.Success(result);
    }
}
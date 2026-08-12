using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecUserSecurableValue.Queries;

public class GetAllSecUserSecurableValueQuery
: IQuery<Result<PagingSortingFiltering<SecUserSecurableValueDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecUserSecurableValueQueryHandler :
    IQueryHandler<GetAllSecUserSecurableValueQuery,
        Result<PagingSortingFiltering<SecUserSecurableValueDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecUserSecurableValueQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecUserSecurableValueDetailsResponse>>> Handle(
        GetAllSecUserSecurableValueQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecUserSecurableValueRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecUserSecurableValueDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecUserSecurableValueDetailsResponse>>.Success(result);
    }
}
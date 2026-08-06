using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecRoleSecurableValue.Queries;

public class GetAllSecRoleSecurableValueQuery
: IQuery<Result<PagingSortingFiltering<SecRoleSecurableValueDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecRoleSecurableValueQueryHandler :
    IQueryHandler<GetAllSecRoleSecurableValueQuery,
        Result<PagingSortingFiltering<SecRoleSecurableValueDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecRoleSecurableValueQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecRoleSecurableValueDetailsResponse>>> Handle(
        GetAllSecRoleSecurableValueQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecRoleSecurableValueRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecRoleSecurableValueDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecRoleSecurableValueDetailsResponse>>.Success(result);
    }
}
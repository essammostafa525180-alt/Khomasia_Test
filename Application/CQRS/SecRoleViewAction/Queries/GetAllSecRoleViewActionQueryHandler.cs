using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecRoleViewAction.Queries;

public class GetAllSecRoleViewActionQuery
: IQuery<Result<PagingSortingFiltering<SecRoleViewActionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecRoleViewActionQueryHandler :
    IQueryHandler<GetAllSecRoleViewActionQuery,
        Result<PagingSortingFiltering<SecRoleViewActionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecRoleViewActionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecRoleViewActionDetailsResponse>>> Handle(
        GetAllSecRoleViewActionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecRoleViewActionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecRoleViewActionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecRoleViewActionDetailsResponse>>.Success(result);
    }
}
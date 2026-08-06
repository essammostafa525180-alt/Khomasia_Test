using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecRoleModule.Queries;

public class GetAllSecRoleModuleQuery
: IQuery<Result<PagingSortingFiltering<SecRoleModuleDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecRoleModuleQueryHandler :
    IQueryHandler<GetAllSecRoleModuleQuery,
        Result<PagingSortingFiltering<SecRoleModuleDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecRoleModuleQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecRoleModuleDetailsResponse>>> Handle(
        GetAllSecRoleModuleQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecRoleModuleRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecRoleModuleDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecRoleModuleDetailsResponse>>.Success(result);
    }
}
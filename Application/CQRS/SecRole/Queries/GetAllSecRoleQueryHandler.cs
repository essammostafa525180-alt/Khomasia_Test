using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecRole.Queries;

public class GetAllSecRoleQuery
: IQuery<Result<PagingSortingFiltering<SecRoleDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecRoleQueryHandler :
    IQueryHandler<GetAllSecRoleQuery,
        Result<PagingSortingFiltering<SecRoleDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecRoleQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecRoleDetailsResponse>>> Handle(
        GetAllSecRoleQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecRoleRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecRoleDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecRoleDetailsResponse>>.Success(result);
    }
}
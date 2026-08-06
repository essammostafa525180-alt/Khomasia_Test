using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecRoleProperty.Queries;

public class GetAllSecRolePropertyQuery
: IQuery<Result<PagingSortingFiltering<SecRolePropertyDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecRolePropertyQueryHandler :
    IQueryHandler<GetAllSecRolePropertyQuery,
        Result<PagingSortingFiltering<SecRolePropertyDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecRolePropertyQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecRolePropertyDetailsResponse>>> Handle(
        GetAllSecRolePropertyQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecRolePropertyRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecRolePropertyDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecRolePropertyDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecRoleModelAttribute.Queries;

public class GetAllSecRoleModelAttributeQuery
: IQuery<Result<PagingSortingFiltering<SecRoleModelAttributeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecRoleModelAttributeQueryHandler :
    IQueryHandler<GetAllSecRoleModelAttributeQuery,
        Result<PagingSortingFiltering<SecRoleModelAttributeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecRoleModelAttributeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecRoleModelAttributeDetailsResponse>>> Handle(
        GetAllSecRoleModelAttributeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecRoleModelAttributeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecRoleModelAttributeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecRoleModelAttributeDetailsResponse>>.Success(result);
    }
}
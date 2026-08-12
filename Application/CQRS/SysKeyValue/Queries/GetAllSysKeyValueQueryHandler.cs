using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SysKeyValue.Queries;

public class GetAllSysKeyValueQuery
: IQuery<Result<PagingSortingFiltering<SysKeyValueDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSysKeyValueQueryHandler :
    IQueryHandler<GetAllSysKeyValueQuery,
        Result<PagingSortingFiltering<SysKeyValueDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSysKeyValueQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SysKeyValueDetailsResponse>>> Handle(
        GetAllSysKeyValueQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SysKeyValueRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SysKeyValueDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SysKeyValueDetailsResponse>>.Success(result);
    }
}
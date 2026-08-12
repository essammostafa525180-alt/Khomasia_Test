using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecUserModule.Queries;

public class GetAllSecUserModuleQuery
: IQuery<Result<PagingSortingFiltering<SecUserModuleDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecUserModuleQueryHandler :
    IQueryHandler<GetAllSecUserModuleQuery,
        Result<PagingSortingFiltering<SecUserModuleDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecUserModuleQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecUserModuleDetailsResponse>>> Handle(
        GetAllSecUserModuleQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecUserModuleRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecUserModuleDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecUserModuleDetailsResponse>>.Success(result);
    }
}
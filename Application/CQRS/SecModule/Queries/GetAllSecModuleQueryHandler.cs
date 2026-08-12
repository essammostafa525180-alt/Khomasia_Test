using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecModule.Queries;

public class GetAllSecModuleQuery
: IQuery<Result<PagingSortingFiltering<SecModuleDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecModuleQueryHandler :
    IQueryHandler<GetAllSecModuleQuery,
        Result<PagingSortingFiltering<SecModuleDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecModuleQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecModuleDetailsResponse>>> Handle(
        GetAllSecModuleQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecModuleRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecModuleDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecModuleDetailsResponse>>.Success(result);
    }
}
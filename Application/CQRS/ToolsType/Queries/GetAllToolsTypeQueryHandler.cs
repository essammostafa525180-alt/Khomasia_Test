using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ToolsType.Queries;

public class GetAllToolsTypeQuery
: IQuery<Result<PagingSortingFiltering<ToolsTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllToolsTypeQueryHandler :
    IQueryHandler<GetAllToolsTypeQuery,
        Result<PagingSortingFiltering<ToolsTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllToolsTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ToolsTypeDetailsResponse>>> Handle(
        GetAllToolsTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ToolsTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ToolsTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ToolsTypeDetailsResponse>>.Success(result);
    }
}
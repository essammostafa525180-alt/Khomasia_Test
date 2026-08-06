using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.EngineSize.Queries;

public class GetAllEngineSizeQuery
: IQuery<Result<PagingSortingFiltering<EngineSizeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllEngineSizeQueryHandler :
    IQueryHandler<GetAllEngineSizeQuery,
        Result<PagingSortingFiltering<EngineSizeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEngineSizeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<EngineSizeDetailsResponse>>> Handle(
        GetAllEngineSizeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.EngineSizeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<EngineSizeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<EngineSizeDetailsResponse>>.Success(result);
    }
}
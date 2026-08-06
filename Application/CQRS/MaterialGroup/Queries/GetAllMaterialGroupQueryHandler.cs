using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.MaterialGroup.Queries;

public class GetAllMaterialGroupQuery
: IQuery<Result<PagingSortingFiltering<MaterialGroupDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllMaterialGroupQueryHandler :
    IQueryHandler<GetAllMaterialGroupQuery,
        Result<PagingSortingFiltering<MaterialGroupDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMaterialGroupQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<MaterialGroupDetailsResponse>>> Handle(
        GetAllMaterialGroupQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.MaterialGroupRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<MaterialGroupDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<MaterialGroupDetailsResponse>>.Success(result);
    }
}
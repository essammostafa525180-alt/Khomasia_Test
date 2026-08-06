using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.MaterialCategory.Queries;

public class GetAllMaterialCategoryQuery
: IQuery<Result<PagingSortingFiltering<MaterialCategoryDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllMaterialCategoryQueryHandler :
    IQueryHandler<GetAllMaterialCategoryQuery,
        Result<PagingSortingFiltering<MaterialCategoryDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMaterialCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<MaterialCategoryDetailsResponse>>> Handle(
        GetAllMaterialCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.MaterialCategoryRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<MaterialCategoryDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<MaterialCategoryDetailsResponse>>.Success(result);
    }
}
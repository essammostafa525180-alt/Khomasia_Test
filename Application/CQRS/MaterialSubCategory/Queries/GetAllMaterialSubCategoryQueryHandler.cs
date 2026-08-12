using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.MaterialSubCategory.Queries;

public class GetAllMaterialSubCategoryQuery
: IQuery<Result<PagingSortingFiltering<MaterialSubCategoryDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllMaterialSubCategoryQueryHandler :
    IQueryHandler<GetAllMaterialSubCategoryQuery,
        Result<PagingSortingFiltering<MaterialSubCategoryDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMaterialSubCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<MaterialSubCategoryDetailsResponse>>> Handle(
        GetAllMaterialSubCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.MaterialSubCategoryRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<MaterialSubCategoryDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<MaterialSubCategoryDetailsResponse>>.Success(result);
    }
}
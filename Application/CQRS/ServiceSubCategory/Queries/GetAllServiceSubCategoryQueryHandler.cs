using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ServiceSubCategory.Queries;

public class GetAllServiceSubCategoryQuery
: IQuery<Result<PagingSortingFiltering<ServiceSubCategoryDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllServiceSubCategoryQueryHandler :
    IQueryHandler<GetAllServiceSubCategoryQuery,
        Result<PagingSortingFiltering<ServiceSubCategoryDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllServiceSubCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ServiceSubCategoryDetailsResponse>>> Handle(
        GetAllServiceSubCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ServiceSubCategoryRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ServiceSubCategoryDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ServiceSubCategoryDetailsResponse>>.Success(result);
    }
}
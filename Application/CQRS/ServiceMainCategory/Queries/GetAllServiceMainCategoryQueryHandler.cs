using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ServiceMainCategory.Queries;

public class GetAllServiceMainCategoryQuery
: IQuery<Result<PagingSortingFiltering<ServiceMainCategoryDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllServiceMainCategoryQueryHandler :
    IQueryHandler<GetAllServiceMainCategoryQuery,
        Result<PagingSortingFiltering<ServiceMainCategoryDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllServiceMainCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ServiceMainCategoryDetailsResponse>>> Handle(
        GetAllServiceMainCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ServiceMainCategoryRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ServiceMainCategoryDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ServiceMainCategoryDetailsResponse>>.Success(result);
    }
}
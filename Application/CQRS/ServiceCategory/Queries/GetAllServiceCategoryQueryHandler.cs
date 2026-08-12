using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ServiceCategory.Queries;

public class GetAllServiceCategoryQuery
: IQuery<Result<PagingSortingFiltering<ServiceCategoryDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllServiceCategoryQueryHandler :
    IQueryHandler<GetAllServiceCategoryQuery,
        Result<PagingSortingFiltering<ServiceCategoryDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllServiceCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ServiceCategoryDetailsResponse>>> Handle(
        GetAllServiceCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ServiceCategoryRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ServiceCategoryDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ServiceCategoryDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PoserviceRecomendedResource.Queries;

public class GetAllPoserviceRecomendedResourceQuery
: IQuery<Result<PagingSortingFiltering<PoserviceRecomendedResourceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPoserviceRecomendedResourceQueryHandler :
    IQueryHandler<GetAllPoserviceRecomendedResourceQuery,
        Result<PagingSortingFiltering<PoserviceRecomendedResourceDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPoserviceRecomendedResourceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PoserviceRecomendedResourceDetailsResponse>>> Handle(
        GetAllPoserviceRecomendedResourceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PoserviceRecomendedResourceRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PoserviceRecomendedResourceDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PoserviceRecomendedResourceDetailsResponse>>.Success(result);
    }
}
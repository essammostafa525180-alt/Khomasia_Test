using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetsType.Queries;

public class GetAllAssetsTypeQuery
: IQuery<Result<PagingSortingFiltering<AssetsTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetsTypeQueryHandler :
    IQueryHandler<GetAllAssetsTypeQuery,
        Result<PagingSortingFiltering<AssetsTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetsTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetsTypeDetailsResponse>>> Handle(
        GetAllAssetsTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetsTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetsTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetsTypeDetailsResponse>>.Success(result);
    }
}
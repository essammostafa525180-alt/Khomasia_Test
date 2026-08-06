using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ItemType.Queries;

public class GetAllItemTypeQuery
: IQuery<Result<PagingSortingFiltering<ItemTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllItemTypeQueryHandler :
    IQueryHandler<GetAllItemTypeQuery,
        Result<PagingSortingFiltering<ItemTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllItemTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ItemTypeDetailsResponse>>> Handle(
        GetAllItemTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ItemTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ItemTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ItemTypeDetailsResponse>>.Success(result);
    }
}
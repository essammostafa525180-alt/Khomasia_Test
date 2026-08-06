using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ItemExpiryType.Queries;

public class GetAllItemExpiryTypeQuery
: IQuery<Result<PagingSortingFiltering<ItemExpiryTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllItemExpiryTypeQueryHandler :
    IQueryHandler<GetAllItemExpiryTypeQuery,
        Result<PagingSortingFiltering<ItemExpiryTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllItemExpiryTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ItemExpiryTypeDetailsResponse>>> Handle(
        GetAllItemExpiryTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ItemExpiryTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ItemExpiryTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ItemExpiryTypeDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ItemQuantityType.Queries;

public class GetAllItemQuantityTypeQuery
: IQuery<Result<PagingSortingFiltering<ItemQuantityTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllItemQuantityTypeQueryHandler :
    IQueryHandler<GetAllItemQuantityTypeQuery,
        Result<PagingSortingFiltering<ItemQuantityTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllItemQuantityTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ItemQuantityTypeDetailsResponse>>> Handle(
        GetAllItemQuantityTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ItemQuantityTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ItemQuantityTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ItemQuantityTypeDetailsResponse>>.Success(result);
    }
}
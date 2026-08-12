using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Shelf.Queries;

public class GetAllShelfQuery
: IQuery<Result<PagingSortingFiltering<ShelfDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllShelfQueryHandler :
    IQueryHandler<GetAllShelfQuery,
        Result<PagingSortingFiltering<ShelfDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllShelfQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ShelfDetailsResponse>>> Handle(
        GetAllShelfQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ShelfRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ShelfDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ShelfDetailsResponse>>.Success(result);
    }
}
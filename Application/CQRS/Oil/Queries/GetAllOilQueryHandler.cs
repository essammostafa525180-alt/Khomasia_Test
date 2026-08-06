using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Oil.Queries;

public class GetAllOilQuery
: IQuery<Result<PagingSortingFiltering<OilDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllOilQueryHandler :
    IQueryHandler<GetAllOilQuery,
        Result<PagingSortingFiltering<OilDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOilQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<OilDetailsResponse>>> Handle(
        GetAllOilQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.OilRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<OilDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<OilDetailsResponse>>.Success(result);
    }
}
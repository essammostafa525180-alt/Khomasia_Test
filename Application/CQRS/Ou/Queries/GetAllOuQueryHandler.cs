using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ou.Queries;

public class GetAllOuQuery
: IQuery<Result<PagingSortingFiltering<OuDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllOuQueryHandler :
    IQueryHandler<GetAllOuQuery,
        Result<PagingSortingFiltering<OuDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOuQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<OuDetailsResponse>>> Handle(
        GetAllOuQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.OuRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<OuDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<OuDetailsResponse>>.Success(result);
    }
}
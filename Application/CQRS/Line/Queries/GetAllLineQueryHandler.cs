using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Line.Queries;

public class GetAllLineQuery
: IQuery<Result<PagingSortingFiltering<LineDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllLineQueryHandler :
    IQueryHandler<GetAllLineQuery,
        Result<PagingSortingFiltering<LineDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLineQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<LineDetailsResponse>>> Handle(
        GetAllLineQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.LineRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<LineDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<LineDetailsResponse>>.Success(result);
    }
}
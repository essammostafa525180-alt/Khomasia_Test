using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Isle.Queries;

public class GetAllIsleQuery
: IQuery<Result<PagingSortingFiltering<IsleDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllIsleQueryHandler :
    IQueryHandler<GetAllIsleQuery,
        Result<PagingSortingFiltering<IsleDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllIsleQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<IsleDetailsResponse>>> Handle(
        GetAllIsleQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.IsleRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<IsleDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<IsleDetailsResponse>>.Success(result);
    }
}
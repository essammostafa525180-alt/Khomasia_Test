using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RwPickedBatch.Queries;

public class GetAllRwPickedBatchQuery
: IQuery<Result<PagingSortingFiltering<RwPickedBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRwPickedBatchQueryHandler :
    IQueryHandler<GetAllRwPickedBatchQuery,
        Result<PagingSortingFiltering<RwPickedBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRwPickedBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RwPickedBatchDetailsResponse>>> Handle(
        GetAllRwPickedBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RwPickedBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RwPickedBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RwPickedBatchDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.WorkerType.Queries;

public class GetAllWorkerTypeQuery
: IQuery<Result<PagingSortingFiltering<WorkerTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllWorkerTypeQueryHandler :
    IQueryHandler<GetAllWorkerTypeQuery,
        Result<PagingSortingFiltering<WorkerTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWorkerTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<WorkerTypeDetailsResponse>>> Handle(
        GetAllWorkerTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.WorkerTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<WorkerTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<WorkerTypeDetailsResponse>>.Success(result);
    }
}
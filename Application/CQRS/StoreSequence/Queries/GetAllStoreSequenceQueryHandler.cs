using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.StoreSequence.Queries;

public class GetAllStoreSequenceQuery
: IQuery<Result<PagingSortingFiltering<StoreSequenceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllStoreSequenceQueryHandler :
    IQueryHandler<GetAllStoreSequenceQuery,
        Result<PagingSortingFiltering<StoreSequenceDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStoreSequenceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<StoreSequenceDetailsResponse>>> Handle(
        GetAllStoreSequenceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.StoreSequenceRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<StoreSequenceDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<StoreSequenceDetailsResponse>>.Success(result);
    }
}
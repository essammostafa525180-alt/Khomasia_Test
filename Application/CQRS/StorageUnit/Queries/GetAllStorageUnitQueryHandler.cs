using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.StorageUnit.Queries;

public class GetAllStorageUnitQuery
: IQuery<Result<PagingSortingFiltering<StorageUnitDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllStorageUnitQueryHandler :
    IQueryHandler<GetAllStorageUnitQuery,
        Result<PagingSortingFiltering<StorageUnitDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStorageUnitQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<StorageUnitDetailsResponse>>> Handle(
        GetAllStorageUnitQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.StorageUnitRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<StorageUnitDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<StorageUnitDetailsResponse>>.Success(result);
    }
}

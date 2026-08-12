using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SparePartGroup.Queries;

public class GetAllSparePartGroupQuery
: IQuery<Result<PagingSortingFiltering<SparePartGroupDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSparePartGroupQueryHandler :
    IQueryHandler<GetAllSparePartGroupQuery,
        Result<PagingSortingFiltering<SparePartGroupDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSparePartGroupQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SparePartGroupDetailsResponse>>> Handle(
        GetAllSparePartGroupQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SparePartGroupRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SparePartGroupDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SparePartGroupDetailsResponse>>.Success(result);
    }
}
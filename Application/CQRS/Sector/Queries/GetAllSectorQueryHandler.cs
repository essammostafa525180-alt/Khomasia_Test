using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Sector.Queries;

public class GetAllSectorQuery
: IQuery<Result<PagingSortingFiltering<SectorDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSectorQueryHandler :
    IQueryHandler<GetAllSectorQuery,
        Result<PagingSortingFiltering<SectorDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSectorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SectorDetailsResponse>>> Handle(
        GetAllSectorQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SectorRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SectorDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SectorDetailsResponse>>.Success(result);
    }
}
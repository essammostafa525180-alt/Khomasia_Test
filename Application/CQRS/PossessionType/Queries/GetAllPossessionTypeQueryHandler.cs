using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PossessionType.Queries;

public class GetAllPossessionTypeQuery
: IQuery<Result<PagingSortingFiltering<PossessionTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPossessionTypeQueryHandler :
    IQueryHandler<GetAllPossessionTypeQuery,
        Result<PagingSortingFiltering<PossessionTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPossessionTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PossessionTypeDetailsResponse>>> Handle(
        GetAllPossessionTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PossessionTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PossessionTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PossessionTypeDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecViewAction.Queries;

public class GetAllSecViewActionQuery
: IQuery<Result<PagingSortingFiltering<SecViewActionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecViewActionQueryHandler :
    IQueryHandler<GetAllSecViewActionQuery,
        Result<PagingSortingFiltering<SecViewActionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecViewActionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecViewActionDetailsResponse>>> Handle(
        GetAllSecViewActionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecViewActionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecViewActionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecViewActionDetailsResponse>>.Success(result);
    }
}
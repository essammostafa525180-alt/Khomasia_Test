using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.SecView.Queries;

public class GetAllSecViewQuery
: IQuery<Result<PagingSortingFiltering<SecViewDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSecViewQueryHandler :
    IQueryHandler<GetAllSecViewQuery,
        Result<PagingSortingFiltering<SecViewDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSecViewQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<SecViewDetailsResponse>>> Handle(
        GetAllSecViewQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SecViewRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<SecViewDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<SecViewDetailsResponse>>.Success(result);
    }
}
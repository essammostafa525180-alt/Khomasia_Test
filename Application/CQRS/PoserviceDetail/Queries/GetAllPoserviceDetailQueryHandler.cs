using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PoserviceDetail.Queries;

public class GetAllPoserviceDetailQuery
: IQuery<Result<PagingSortingFiltering<PoserviceDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPoserviceDetailQueryHandler :
    IQueryHandler<GetAllPoserviceDetailQuery,
        Result<PagingSortingFiltering<PoserviceDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPoserviceDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PoserviceDetailDetailsResponse>>> Handle(
        GetAllPoserviceDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PoserviceDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PoserviceDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PoserviceDetailDetailsResponse>>.Success(result);
    }
}
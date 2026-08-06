using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Service.Queries;

public class GetAllServiceQuery
: IQuery<Result<PagingSortingFiltering<ServiceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllServiceQueryHandler :
    IQueryHandler<GetAllServiceQuery,
        Result<PagingSortingFiltering<ServiceDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllServiceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ServiceDetailsResponse>>> Handle(
        GetAllServiceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ServiceRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ServiceDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ServiceDetailsResponse>>.Success(result);
    }
}
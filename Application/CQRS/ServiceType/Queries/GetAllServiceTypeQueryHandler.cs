using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ServiceType.Queries;

public class GetAllServiceTypeQuery
: IQuery<Result<PagingSortingFiltering<ServiceTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllServiceTypeQueryHandler :
    IQueryHandler<GetAllServiceTypeQuery,
        Result<PagingSortingFiltering<ServiceTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllServiceTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ServiceTypeDetailsResponse>>> Handle(
        GetAllServiceTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ServiceTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ServiceTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ServiceTypeDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PoserviceType.Queries;

public class GetAllPoserviceTypeQuery
: IQuery<Result<PagingSortingFiltering<PoserviceTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPoserviceTypeQueryHandler :
    IQueryHandler<GetAllPoserviceTypeQuery,
        Result<PagingSortingFiltering<PoserviceTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPoserviceTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PoserviceTypeDetailsResponse>>> Handle(
        GetAllPoserviceTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PoserviceTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PoserviceTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PoserviceTypeDetailsResponse>>.Success(result);
    }
}
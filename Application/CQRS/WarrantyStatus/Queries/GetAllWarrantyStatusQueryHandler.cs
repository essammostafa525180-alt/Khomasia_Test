using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.WarrantyStatus.Queries;

public class GetAllWarrantyStatusQuery
: IQuery<Result<PagingSortingFiltering<WarrantyStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllWarrantyStatusQueryHandler :
    IQueryHandler<GetAllWarrantyStatusQuery,
        Result<PagingSortingFiltering<WarrantyStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWarrantyStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<WarrantyStatusDetailsResponse>>> Handle(
        GetAllWarrantyStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.WarrantyStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<WarrantyStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<WarrantyStatusDetailsResponse>>.Success(result);
    }
}
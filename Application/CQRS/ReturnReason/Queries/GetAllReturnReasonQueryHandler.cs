using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ReturnReason.Queries;

public class GetAllReturnReasonQuery
: IQuery<Result<PagingSortingFiltering<ReturnReasonDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllReturnReasonQueryHandler :
    IQueryHandler<GetAllReturnReasonQuery,
        Result<PagingSortingFiltering<ReturnReasonDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllReturnReasonQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ReturnReasonDetailsResponse>>> Handle(
        GetAllReturnReasonQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ReturnReasonRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ReturnReasonDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ReturnReasonDetailsResponse>>.Success(result);
    }
}
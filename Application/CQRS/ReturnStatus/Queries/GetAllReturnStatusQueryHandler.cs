using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ReturnStatus.Queries;

public class GetAllReturnStatusQuery
: IQuery<Result<PagingSortingFiltering<ReturnStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllReturnStatusQueryHandler :
    IQueryHandler<GetAllReturnStatusQuery,
        Result<PagingSortingFiltering<ReturnStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllReturnStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ReturnStatusDetailsResponse>>> Handle(
        GetAllReturnStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ReturnStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ReturnStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ReturnStatusDetailsResponse>>.Success(result);
    }
}
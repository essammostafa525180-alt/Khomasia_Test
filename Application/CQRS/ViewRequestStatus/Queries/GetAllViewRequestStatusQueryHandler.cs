using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ViewRequestStatus.Queries;

public class GetAllViewRequestStatusQuery
: IQuery<Result<PagingSortingFiltering<ViewRequestStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllViewRequestStatusQueryHandler :
    IQueryHandler<GetAllViewRequestStatusQuery,
        Result<PagingSortingFiltering<ViewRequestStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllViewRequestStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ViewRequestStatusDetailsResponse>>> Handle(
        GetAllViewRequestStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ViewRequestStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ViewRequestStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ViewRequestStatusDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.ItemRequestStatus.Queries;

public class GetAllItemRequestStatusQuery
: IQuery<Result<PagingSortingFiltering<ItemRequestStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllItemRequestStatusQueryHandler :
    IQueryHandler<GetAllItemRequestStatusQuery,
        Result<PagingSortingFiltering<ItemRequestStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllItemRequestStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<ItemRequestStatusDetailsResponse>>> Handle(
        GetAllItemRequestStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ItemRequestStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<ItemRequestStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ItemRequestStatusDetailsResponse>>.Success(result);
    }
}
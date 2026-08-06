using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.NotificationPlaceHolder.Queries;

public class GetAllNotificationPlaceHolderQuery
: IQuery<Result<PagingSortingFiltering<NotificationPlaceHolderDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllNotificationPlaceHolderQueryHandler :
    IQueryHandler<GetAllNotificationPlaceHolderQuery,
        Result<PagingSortingFiltering<NotificationPlaceHolderDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificationPlaceHolderQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<NotificationPlaceHolderDetailsResponse>>> Handle(
        GetAllNotificationPlaceHolderQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.NotificationPlaceHolderRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<NotificationPlaceHolderDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<NotificationPlaceHolderDetailsResponse>>.Success(result);
    }
}
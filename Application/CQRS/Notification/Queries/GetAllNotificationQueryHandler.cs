using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Notification.Queries;

public class GetAllNotificationQuery
: IQuery<Result<PagingSortingFiltering<NotificationDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllNotificationQueryHandler :
    IQueryHandler<GetAllNotificationQuery,
        Result<PagingSortingFiltering<NotificationDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<NotificationDetailsResponse>>> Handle(
        GetAllNotificationQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.NotificationRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<NotificationDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<NotificationDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.NotificationLog.Queries;

public class GetAllNotificationLogQuery
: IQuery<Result<PagingSortingFiltering<NotificationLogDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllNotificationLogQueryHandler :
    IQueryHandler<GetAllNotificationLogQuery,
        Result<PagingSortingFiltering<NotificationLogDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificationLogQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<NotificationLogDetailsResponse>>> Handle(
        GetAllNotificationLogQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.NotificationLogRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<NotificationLogDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<NotificationLogDetailsResponse>>.Success(result);
    }
}
using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.NotificationType.Queries;

public class GetAllNotificationTypeQuery
: IQuery<Result<PagingSortingFiltering<NotificationTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllNotificationTypeQueryHandler :
    IQueryHandler<GetAllNotificationTypeQuery,
        Result<PagingSortingFiltering<NotificationTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificationTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<NotificationTypeDetailsResponse>>> Handle(
        GetAllNotificationTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.NotificationTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<NotificationTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<NotificationTypeDetailsResponse>>.Success(result);
    }
}
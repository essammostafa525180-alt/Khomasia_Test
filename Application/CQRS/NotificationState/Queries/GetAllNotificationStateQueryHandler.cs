using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.NotificationState.Queries;

public class GetAllNotificationStateQuery
: IQuery<Result<PagingSortingFiltering<NotificationStateDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllNotificationStateQueryHandler :
    IQueryHandler<GetAllNotificationStateQuery,
        Result<PagingSortingFiltering<NotificationStateDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificationStateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<NotificationStateDetailsResponse>>> Handle(
        GetAllNotificationStateQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.NotificationStateRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<NotificationStateDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<NotificationStateDetailsResponse>>.Success(result);
    }
}
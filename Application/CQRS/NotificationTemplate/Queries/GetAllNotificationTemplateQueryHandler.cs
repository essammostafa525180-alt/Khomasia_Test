using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.NotificationTemplate.Queries;

public class GetAllNotificationTemplateQuery
: IQuery<Result<PagingSortingFiltering<NotificationTemplateDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllNotificationTemplateQueryHandler :
    IQueryHandler<GetAllNotificationTemplateQuery,
        Result<PagingSortingFiltering<NotificationTemplateDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificationTemplateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<NotificationTemplateDetailsResponse>>> Handle(
        GetAllNotificationTemplateQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.NotificationTemplateRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<NotificationTemplateDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<NotificationTemplateDetailsResponse>>.Success(result);
    }
}
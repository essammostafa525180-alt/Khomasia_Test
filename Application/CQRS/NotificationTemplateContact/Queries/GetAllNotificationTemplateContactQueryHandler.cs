using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.NotificationTemplateContact.Queries;

public class GetAllNotificationTemplateContactQuery
: IQuery<Result<PagingSortingFiltering<NotificationTemplateContactDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllNotificationTemplateContactQueryHandler :
    IQueryHandler<GetAllNotificationTemplateContactQuery,
        Result<PagingSortingFiltering<NotificationTemplateContactDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificationTemplateContactQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<NotificationTemplateContactDetailsResponse>>> Handle(
        GetAllNotificationTemplateContactQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.NotificationTemplateContactRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<NotificationTemplateContactDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<NotificationTemplateContactDetailsResponse>>.Success(result);
    }
}
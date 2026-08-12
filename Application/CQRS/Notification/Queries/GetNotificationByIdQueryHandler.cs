using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Notification.Queries;

public class GetNotificationByIdQuery : IQuery<Result<NotificationDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetNotificationByIdQueryHandler : IQueryHandler<GetNotificationByIdQuery, Result<NotificationDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<NotificationDetailsResponse>> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<NotificationDetailsResponse>.Failure(Errors.NotificationNotFound);

        var response = entity.Adapt<NotificationDetailsResponse>();

        return Result<NotificationDetailsResponse>.Success(response);
    }
}
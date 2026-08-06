using Application.Abstractions;
using Mapster;

namespace Application.CQRS.NotificationLog.Queries;

public class GetNotificationLogByIdQuery : IQuery<Result<NotificationLogDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetNotificationLogByIdQueryHandler : IQueryHandler<GetNotificationLogByIdQuery, Result<NotificationLogDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationLogByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<NotificationLogDetailsResponse>> Handle(GetNotificationLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationLogRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<NotificationLogDetailsResponse>.Failure(Errors.NotificationLogNotFound);

        var response = entity.Adapt<NotificationLogDetailsResponse>();

        return Result<NotificationLogDetailsResponse>.Success(response);
    }
}
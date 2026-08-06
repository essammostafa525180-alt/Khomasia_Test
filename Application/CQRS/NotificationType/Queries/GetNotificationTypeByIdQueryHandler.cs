using Application.Abstractions;
using Mapster;

namespace Application.CQRS.NotificationType.Queries;

public class GetNotificationTypeByIdQuery : IQuery<Result<NotificationTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetNotificationTypeByIdQueryHandler : IQueryHandler<GetNotificationTypeByIdQuery, Result<NotificationTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<NotificationTypeDetailsResponse>> Handle(GetNotificationTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<NotificationTypeDetailsResponse>.Failure(Errors.NotificationTypeNotFound);

        var response = entity.Adapt<NotificationTypeDetailsResponse>();

        return Result<NotificationTypeDetailsResponse>.Success(response);
    }
}
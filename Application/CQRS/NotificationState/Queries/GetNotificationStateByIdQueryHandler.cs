using Application.Abstractions;
using Mapster;

namespace Application.CQRS.NotificationState.Queries;

public class GetNotificationStateByIdQuery : IQuery<Result<NotificationStateDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetNotificationStateByIdQueryHandler : IQueryHandler<GetNotificationStateByIdQuery, Result<NotificationStateDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationStateByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<NotificationStateDetailsResponse>> Handle(GetNotificationStateByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationStateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<NotificationStateDetailsResponse>.Failure(Errors.NotificationStateNotFound);

        var response = entity.Adapt<NotificationStateDetailsResponse>();

        return Result<NotificationStateDetailsResponse>.Success(response);
    }
}
using Application.Abstractions;
using Mapster;

namespace Application.CQRS.NotificationTemplate.Queries;

public class GetNotificationTemplateByIdQuery : IQuery<Result<NotificationTemplateDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetNotificationTemplateByIdQueryHandler : IQueryHandler<GetNotificationTemplateByIdQuery, Result<NotificationTemplateDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationTemplateByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<NotificationTemplateDetailsResponse>> Handle(GetNotificationTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTemplateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<NotificationTemplateDetailsResponse>.Failure(Errors.NotificationTemplateNotFound);

        var response = entity.Adapt<NotificationTemplateDetailsResponse>();

        return Result<NotificationTemplateDetailsResponse>.Success(response);
    }
}
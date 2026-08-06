using Application.Abstractions;
using Mapster;

namespace Application.CQRS.NotificationTemplateContact.Queries;

public class GetNotificationTemplateContactByIdQuery : IQuery<Result<NotificationTemplateContactDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetNotificationTemplateContactByIdQueryHandler : IQueryHandler<GetNotificationTemplateContactByIdQuery, Result<NotificationTemplateContactDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationTemplateContactByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<NotificationTemplateContactDetailsResponse>> Handle(GetNotificationTemplateContactByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTemplateContactRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<NotificationTemplateContactDetailsResponse>.Failure(Errors.NotificationTemplateContactNotFound);

        var response = entity.Adapt<NotificationTemplateContactDetailsResponse>();

        return Result<NotificationTemplateContactDetailsResponse>.Success(response);
    }
}
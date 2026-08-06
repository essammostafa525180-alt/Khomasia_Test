using Application.Abstractions;

namespace Application.CQRS.NotificationTemplate.Commands;

public class CreateNotificationTemplateCommand : ICommand<Result<int>>
{
        public int? NotificationTypeId { get; set; }
        public int? LanguageId { get; set; }
        public string? Subject { get; set; }
        public string? SubjectAr { get; set; }
        public string? BodySms { get; set; }
        public string? BodySmsar { get; set; }
        public string? BodyEmail { get; set; }
        public string? BodyEmailAr { get; set; }
        public string? Code { get; set; }
        public string? CodeAr { get; set; }
        public int? DurationInDays { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateNotificationTemplateCommandHandler : ICommandHandler<CreateNotificationTemplateCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNotificationTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateNotificationTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.NotificationAggregate.NotificationTemplate.Create(request.NotificationTypeId, request.LanguageId, request.Subject, request.SubjectAr, request.BodySms, request.BodySmsar, request.BodyEmail, request.BodyEmailAr, request.Code, request.CodeAr, request.DurationInDays, request.IsActive);

        await _unitOfWork.NotificationTemplateRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.NotificationTemplateNotInserted);
    }
}
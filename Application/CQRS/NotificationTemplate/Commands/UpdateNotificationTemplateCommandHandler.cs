using Application.Abstractions;

namespace Application.CQRS.NotificationTemplate.Commands;

public class UpdateNotificationTemplateCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateNotificationTemplateCommandHandler : ICommandHandler<UpdateNotificationTemplateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateNotificationTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTemplateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationTemplateNotFound);

        entity.Update(request.NotificationTypeId, request.LanguageId, request.Subject, request.SubjectAr, request.BodySms, request.BodySmsar, request.BodyEmail, request.BodyEmailAr, request.Code, request.CodeAr, request.DurationInDays, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationTemplateNotUpdated);
    }
}
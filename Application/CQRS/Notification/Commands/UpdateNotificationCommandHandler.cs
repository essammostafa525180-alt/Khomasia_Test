using Application.Abstractions;

namespace Application.CQRS.Notification.Commands;

public class UpdateNotificationCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? To { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? SendDate { get; set; }
        public int? NotificationTypeId { get; set; }
        public string? NotificationSource { get; set; }
        public string? ErrorMessage { get; set; }
        public int? SendTries { get; set; }
        public DateTime? NotificationDateTime { get; set; }
        public byte[]? Attachment { get; set; }
        public string? AttachmentType { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateNotificationCommandHandler : ICommandHandler<UpdateNotificationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationNotFound);

        entity.Update(request.To, request.Cc, request.Bcc, request.PhoneNumber, request.Subject, request.Body, request.StatusId, request.CreateDate, request.LastUpdateDate, request.SendDate, request.NotificationTypeId, request.NotificationSource, request.ErrorMessage, request.SendTries, request.NotificationDateTime, request.Attachment, request.AttachmentType, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationNotUpdated);
    }
}
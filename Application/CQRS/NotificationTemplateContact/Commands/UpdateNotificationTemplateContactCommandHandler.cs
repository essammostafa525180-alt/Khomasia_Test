using Application.Abstractions;

namespace Application.CQRS.NotificationTemplateContact.Commands;

public class UpdateNotificationTemplateContactCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? ContactId { get; set; }
        public int? TemplateId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateNotificationTemplateContactCommandHandler : ICommandHandler<UpdateNotificationTemplateContactCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationTemplateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateNotificationTemplateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTemplateContactRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationTemplateContactNotFound);

        entity.Update(request.ContactId, request.TemplateId, request.UpdatedOn, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationTemplateContactNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.NotificationTemplateContact.Commands;

public class DeleteNotificationTemplateContactCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteNotificationTemplateContactCommandHandler : ICommandHandler<DeleteNotificationTemplateContactCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationTemplateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteNotificationTemplateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTemplateContactRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationTemplateContactNotFound);

        _unitOfWork.NotificationTemplateContactRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationTemplateContactNotDeleted);
    }
}
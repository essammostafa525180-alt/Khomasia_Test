using Application.Abstractions;

namespace Application.CQRS.NotificationTemplate.Commands;

public class DeleteNotificationTemplateCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteNotificationTemplateCommandHandler : ICommandHandler<DeleteNotificationTemplateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteNotificationTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTemplateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationTemplateNotFound);

        _unitOfWork.NotificationTemplateRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationTemplateNotDeleted);
    }
}
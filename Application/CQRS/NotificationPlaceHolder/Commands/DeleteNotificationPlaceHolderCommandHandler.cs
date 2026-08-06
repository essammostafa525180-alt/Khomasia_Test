using Application.Abstractions;

namespace Application.CQRS.NotificationPlaceHolder.Commands;

public class DeleteNotificationPlaceHolderCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteNotificationPlaceHolderCommandHandler : ICommandHandler<DeleteNotificationPlaceHolderCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationPlaceHolderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteNotificationPlaceHolderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationPlaceHolderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationPlaceHolderNotFound);

        _unitOfWork.NotificationPlaceHolderRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationPlaceHolderNotDeleted);
    }
}
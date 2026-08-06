using Application.Abstractions;

namespace Application.CQRS.NotificationState.Commands;

public class UpdateNotificationStateCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? StatusName { get; set; }
        public string? StatusNameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateNotificationStateCommandHandler : ICommandHandler<UpdateNotificationStateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationStateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateNotificationStateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationStateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationStateNotFound);

        entity.Update(request.StatusName, request.StatusNameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationStateNotUpdated);
    }
}
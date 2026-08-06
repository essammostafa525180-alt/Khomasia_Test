using Application.Abstractions;

namespace Application.CQRS.NotificationType.Commands;

public class CreateNotificationTypeCommand : ICommand<Result<int>>
{
        public string? NotificationTypeEn { get; set; }
        public string? NotificationTypeAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateNotificationTypeCommandHandler : ICommandHandler<CreateNotificationTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNotificationTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateNotificationTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.NotificationType.Create(request.NotificationTypeEn, request.NotificationTypeAr, request.IsActive);

        await _unitOfWork.NotificationTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.NotificationTypeNotInserted);
    }
}
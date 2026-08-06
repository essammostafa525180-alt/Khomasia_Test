using Application.Abstractions;

namespace Application.CQRS.NotificationState.Commands;

public class CreateNotificationStateCommand : ICommand<Result<int>>
{
        public string? StatusName { get; set; }
        public string? StatusNameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateNotificationStateCommandHandler : ICommandHandler<CreateNotificationStateCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNotificationStateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateNotificationStateCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.NotificationState.Create(request.StatusName, request.StatusNameAr, request.IsActive);

        await _unitOfWork.NotificationStateRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.NotificationStateNotInserted);
    }
}
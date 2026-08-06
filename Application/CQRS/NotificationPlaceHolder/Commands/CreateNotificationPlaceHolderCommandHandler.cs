using Application.Abstractions;

namespace Application.CQRS.NotificationPlaceHolder.Commands;

public class CreateNotificationPlaceHolderCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateNotificationPlaceHolderCommandHandler : ICommandHandler<CreateNotificationPlaceHolderCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNotificationPlaceHolderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateNotificationPlaceHolderCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.NotificationPlaceHolder.Create(request.Name, request.NameAr, request.Value, request.IsActive);

        await _unitOfWork.NotificationPlaceHolderRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.NotificationPlaceHolderNotInserted);
    }
}
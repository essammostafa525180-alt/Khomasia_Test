using Application.Abstractions;

namespace Application.CQRS.NotificationPlaceHolder.Commands;

public class UpdateNotificationPlaceHolderCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateNotificationPlaceHolderCommandHandler : ICommandHandler<UpdateNotificationPlaceHolderCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationPlaceHolderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateNotificationPlaceHolderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationPlaceHolderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationPlaceHolderNotFound);

        entity.Update(request.Name, request.NameAr, request.Value, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationPlaceHolderNotUpdated);
    }
}
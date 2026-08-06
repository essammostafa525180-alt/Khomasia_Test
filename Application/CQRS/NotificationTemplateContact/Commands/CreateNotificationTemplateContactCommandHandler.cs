using Application.Abstractions;

namespace Application.CQRS.NotificationTemplateContact.Commands;

public class CreateNotificationTemplateContactCommand : ICommand<Result<int>>
{
        public int? ContactId { get; set; }
        public int? TemplateId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateNotificationTemplateContactCommandHandler : ICommandHandler<CreateNotificationTemplateContactCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNotificationTemplateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateNotificationTemplateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.NotificationAggregate.NotificationTemplateContact.Create(request.ContactId, request.TemplateId, request.UpdatedOn, request.IsActive);

        await _unitOfWork.NotificationTemplateContactRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.NotificationTemplateContactNotInserted);
    }
}
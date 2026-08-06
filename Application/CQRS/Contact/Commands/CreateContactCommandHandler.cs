using Application.Abstractions;

namespace Application.CQRS.Contact.Commands;

public class CreateContactCommand : ICommand<Result<int>>
{
        public string? ContactValue { get; set; }
        public int? ContactTypeId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateContactCommandHandler : ICommandHandler<CreateContactCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SalesAggregate.Contact.Create(request.ContactValue, request.ContactTypeId, request.UpdatedOn, request.IsActive);

        await _unitOfWork.ContactRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ContactNotInserted);
    }
}
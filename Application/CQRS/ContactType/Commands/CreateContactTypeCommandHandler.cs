using Application.Abstractions;

namespace Application.CQRS.ContactType.Commands;

public class CreateContactTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateContactTypeCommandHandler : ICommandHandler<CreateContactTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateContactTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ContactType.Create(request.Name, request.NameAr, request.UpdatedOn, request.IsActive);

        await _unitOfWork.ContactTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ContactTypeNotInserted);
    }
}
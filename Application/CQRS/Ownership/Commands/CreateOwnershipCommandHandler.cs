using Application.Abstractions;

namespace Application.CQRS.Ownership.Commands;

public class CreateOwnershipCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateOwnershipCommandHandler : ICommandHandler<CreateOwnershipCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOwnershipCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateOwnershipCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Ownership.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.OwnershipRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.OwnershipNotInserted);
    }
}
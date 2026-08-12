using Application.Abstractions;

namespace Application.CQRS.Pruser.Commands;

public class CreatePruserCommand : ICommand<Result<int>>
{
        public int ApprovalScreenFk { get; set; }
        public int UserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePruserCommandHandler : ICommandHandler<CreatePruserCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePruserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePruserCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.UserAggregate.Pruser.Create(request.ApprovalScreenFk, request.UserFk, request.IsActive);

        await _unitOfWork.PruserRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PruserNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.Ownership.Commands;

public class DeleteOwnershipCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteOwnershipCommandHandler : ICommandHandler<DeleteOwnershipCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOwnershipCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOwnershipCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OwnershipRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.OwnershipNotFound);

        _unitOfWork.OwnershipRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.OwnershipNotDeleted);
    }
}
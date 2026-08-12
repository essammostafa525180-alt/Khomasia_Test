using Application.Abstractions;

namespace Application.CQRS.Pruser.Commands;

public class DeletePruserCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePruserCommandHandler : ICommandHandler<DeletePruserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePruserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePruserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PruserRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PruserNotFound);

        _unitOfWork.PruserRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PruserNotDeleted);
    }
}
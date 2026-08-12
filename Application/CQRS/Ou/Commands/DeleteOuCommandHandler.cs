using Application.Abstractions;

namespace Application.CQRS.Ou.Commands;

public class DeleteOuCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteOuCommandHandler : ICommandHandler<DeleteOuCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOuCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOuCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OuRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.OuNotFound);

        _unitOfWork.OuRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.OuNotDeleted);
    }
}
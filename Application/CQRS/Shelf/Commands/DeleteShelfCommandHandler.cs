using Application.Abstractions;

namespace Application.CQRS.Shelf.Commands;

public class DeleteShelfCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteShelfCommandHandler : ICommandHandler<DeleteShelfCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteShelfCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteShelfCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ShelfRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ShelfNotFound);

        _unitOfWork.ShelfRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ShelfNotDeleted);
    }
}
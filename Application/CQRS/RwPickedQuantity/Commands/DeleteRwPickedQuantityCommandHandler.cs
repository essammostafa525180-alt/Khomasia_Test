using Application.Abstractions;

namespace Application.CQRS.RwPickedQuantity.Commands;

public class DeleteRwPickedQuantityCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRwPickedQuantityCommandHandler : ICommandHandler<DeleteRwPickedQuantityCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRwPickedQuantityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRwPickedQuantityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RwPickedQuantityRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RwPickedQuantityNotFound);

        _unitOfWork.RwPickedQuantityRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RwPickedQuantityNotDeleted);
    }
}
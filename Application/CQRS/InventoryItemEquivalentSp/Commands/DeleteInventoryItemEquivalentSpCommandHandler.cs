using Application.Abstractions;

namespace Application.CQRS.InventoryItemEquivalentSp.Commands;

public class DeleteInventoryItemEquivalentSpCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemEquivalentSpCommandHandler : ICommandHandler<DeleteInventoryItemEquivalentSpCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemEquivalentSpCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemEquivalentSpCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemEquivalentSpRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemEquivalentSpNotFound);

        _unitOfWork.InventoryItemEquivalentSpRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemEquivalentSpNotDeleted);
    }
}
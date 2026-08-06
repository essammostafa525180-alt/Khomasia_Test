using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocation.Commands;

public class DeleteInventoryItemLocationCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemLocationCommandHandler : ICommandHandler<DeleteInventoryItemLocationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemLocationNotFound);

        _unitOfWork.InventoryItemLocationRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemLocationNotDeleted);
    }
}
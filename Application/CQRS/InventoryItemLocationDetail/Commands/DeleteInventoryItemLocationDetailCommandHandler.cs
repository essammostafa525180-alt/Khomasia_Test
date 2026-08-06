using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationDetail.Commands;

public class DeleteInventoryItemLocationDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemLocationDetailCommandHandler : ICommandHandler<DeleteInventoryItemLocationDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemLocationDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemLocationDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemLocationDetailNotFound);

        _unitOfWork.InventoryItemLocationDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemLocationDetailNotDeleted);
    }
}
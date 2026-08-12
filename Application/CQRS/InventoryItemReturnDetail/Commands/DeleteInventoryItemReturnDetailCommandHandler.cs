using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnDetail.Commands;

public class DeleteInventoryItemReturnDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemReturnDetailCommandHandler : ICommandHandler<DeleteInventoryItemReturnDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemReturnDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemReturnDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnDetailNotFound);

        _unitOfWork.InventoryItemReturnDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnDetailNotDeleted);
    }
}
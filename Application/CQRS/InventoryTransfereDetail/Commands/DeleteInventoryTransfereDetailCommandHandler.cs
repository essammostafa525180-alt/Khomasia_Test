using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetail.Commands;

public class DeleteInventoryTransfereDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryTransfereDetailCommandHandler : ICommandHandler<DeleteInventoryTransfereDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryTransfereDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryTransfereDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereDetailNotFound);

        _unitOfWork.InventoryTransfereDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereDetailNotDeleted);
    }
}
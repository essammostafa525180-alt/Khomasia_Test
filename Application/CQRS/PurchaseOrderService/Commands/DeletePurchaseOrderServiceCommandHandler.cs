using Application.Abstractions;

namespace Application.CQRS.PurchaseOrderService.Commands;

public class DeletePurchaseOrderServiceCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePurchaseOrderServiceCommandHandler : ICommandHandler<DeletePurchaseOrderServiceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePurchaseOrderServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePurchaseOrderServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PurchaseOrderServiceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PurchaseOrderServiceNotFound);

        _unitOfWork.PurchaseOrderServiceRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PurchaseOrderServiceNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryItemVendor.Commands;

public class DeleteInventoryItemVendorCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemVendorCommandHandler : ICommandHandler<DeleteInventoryItemVendorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemVendorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemVendorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemVendorNotFound);

        _unitOfWork.InventoryItemVendorRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemVendorNotDeleted);
    }
}
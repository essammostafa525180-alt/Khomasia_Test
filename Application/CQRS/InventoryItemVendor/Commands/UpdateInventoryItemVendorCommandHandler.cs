using Application.Abstractions;

namespace Application.CQRS.InventoryItemVendor.Commands;

public class UpdateInventoryItemVendorCommand : ICommand<Result>
{
        public int Id { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? VendorFk { get; set; }
        public int? VendorOrder { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemVendorCommandHandler : ICommandHandler<UpdateInventoryItemVendorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemVendorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemVendorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemVendorNotFound);

        entity.Update(request.InventoryItemFk, request.VendorFk, request.VendorOrder, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemVendorNotUpdated);
    }
}
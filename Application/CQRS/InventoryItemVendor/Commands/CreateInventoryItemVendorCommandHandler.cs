using Application.Abstractions;

namespace Application.CQRS.InventoryItemVendor.Commands;

public class CreateInventoryItemVendorCommand : ICommand<Result<int>>
{
        public long? InventoryItemFk { get; set; }
        public int? VendorFk { get; set; }
        public int? VendorOrder { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemVendorCommandHandler : ICommandHandler<CreateInventoryItemVendorCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemVendorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemVendor.Create(request.InventoryItemFk, request.VendorFk, request.VendorOrder, request.IsActive);

        await _unitOfWork.InventoryItemVendorRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemVendorNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VendorReturnSerial.Commands;

public class CreateVendorReturnSerialCommand : ICommand<Result<int>>
{
        public int? VendorReturnFk { get; set; }
        public int? VendorReturnDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorReturnSerialCommandHandler : ICommandHandler<CreateVendorReturnSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorReturnSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorReturnSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorReturnAggregate.VendorReturnSerial.Create(request.VendorReturnFk, request.VendorReturnDetailFk, request.InventoryItemSerialFk, request.IsActive);

        await _unitOfWork.VendorReturnSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorReturnSerialNotInserted);
    }
}
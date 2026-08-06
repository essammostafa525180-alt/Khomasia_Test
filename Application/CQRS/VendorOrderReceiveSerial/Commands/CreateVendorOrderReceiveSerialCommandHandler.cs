using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveSerial.Commands;

public class CreateVendorOrderReceiveSerialCommand : ICommand<Result<int>>
{
        public int? VendorOrderReceiveFk { get; set; }
        public int? VendorOrderReceiveDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderReceiveSerialCommandHandler : ICommandHandler<CreateVendorOrderReceiveSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderReceiveSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderReceiveSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderReceiveSerial.Create(request.VendorOrderReceiveFk, request.VendorOrderReceiveDetailFk, request.InventoryItemSerialFk, request.IsActive);

        await _unitOfWork.VendorOrderReceiveSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderReceiveSerialNotInserted);
    }
}
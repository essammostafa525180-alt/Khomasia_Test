using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveSerial.Commands;

public class UpdateVendorOrderReceiveSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderReceiveFk { get; set; }
        public int? VendorOrderReceiveDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderReceiveSerialCommandHandler : ICommandHandler<UpdateVendorOrderReceiveSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderReceiveSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderReceiveSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveSerialNotFound);

        entity.Update(request.VendorOrderReceiveFk, request.VendorOrderReceiveDetailFk, request.InventoryItemSerialFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveSerialNotUpdated);
    }
}
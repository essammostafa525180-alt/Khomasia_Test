using Application.Abstractions;

namespace Application.CQRS.VendorReturnSerial.Commands;

public class UpdateVendorReturnSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorReturnFk { get; set; }
        public int? VendorReturnDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorReturnSerialCommandHandler : ICommandHandler<UpdateVendorReturnSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorReturnSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorReturnSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorReturnSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorReturnSerialNotFound);

        entity.Update(request.VendorReturnFk, request.VendorReturnDetailFk, request.InventoryItemSerialFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorReturnSerialNotUpdated);
    }
}
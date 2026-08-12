using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetailBatchSerial.Commands;

public class CreateVendorReturnDetailBatchSerialCommand : ICommand<Result<int>>
{
        public int? VendorReturnDetailBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorReturnDetailBatchSerialCommandHandler : ICommandHandler<CreateVendorReturnDetailBatchSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorReturnDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorReturnDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorReturnAggregate.VendorReturnDetailBatchSerial.Create(request.VendorReturnDetailBatchFk, request.SerialFk, request.ReturnReasonFk, request.Notes, request.IsActive);

        await _unitOfWork.VendorReturnDetailBatchSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorReturnDetailBatchSerialNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetailBatchSerial.Commands;

public class CreateVendorOrderReceiveDetailBatchSerialCommand : ICommand<Result<int>>
{
        public int? VendorOrderReceiveDetailBatchFk { get; set; }
        public string? SerialNumber { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderReceiveDetailBatchSerialCommandHandler : ICommandHandler<CreateVendorOrderReceiveDetailBatchSerialCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderReceiveDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderReceiveDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderReceiveDetailBatchSerial.Create(request.VendorOrderReceiveDetailBatchFk, request.SerialNumber, request.IsActive);

        await _unitOfWork.VendorOrderReceiveDetailBatchSerialRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderReceiveDetailBatchSerialNotInserted);
    }
}
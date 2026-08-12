using Application.Abstractions;

namespace Application.CQRS.VendorReturnDetailBatch.Commands;

public class CreateVendorReturnDetailBatchCommand : ICommand<Result<int>>
{
        public int? VendorReturnDetailFk { get; set; }
        public decimal? Quantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public int? BatchFk { get; set; }
        public int? VendorOrderReceiveDetailBatchFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorReturnDetailBatchCommandHandler : ICommandHandler<CreateVendorReturnDetailBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorReturnDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorReturnDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorReturnAggregate.VendorReturnDetailBatch.Create(request.VendorReturnDetailFk, request.Quantity, request.ReturnReasonFk, request.Notes, request.BatchFk, request.VendorOrderReceiveDetailBatchFk, request.IsActive);

        await _unitOfWork.VendorReturnDetailBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorReturnDetailBatchNotInserted);
    }
}
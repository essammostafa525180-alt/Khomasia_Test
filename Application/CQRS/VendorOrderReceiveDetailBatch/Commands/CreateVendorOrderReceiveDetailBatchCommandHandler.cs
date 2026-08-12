using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetailBatch.Commands;

public class CreateVendorOrderReceiveDetailBatchCommand : ICommand<Result<int>>
{
        public int? VendorOrderReceiveDetailFk { get; set; }
        public int? ShelfFk { get; set; }
        public string? BatchNumber { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderReceiveDetailBatchCommandHandler : ICommandHandler<CreateVendorOrderReceiveDetailBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderReceiveDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderReceiveDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderReceiveDetailBatch.Create(request.VendorOrderReceiveDetailFk, request.ShelfFk, request.BatchNumber, request.Quantity, request.ReturnedQuantity, request.ExpiryDate, request.ProductionDate, request.IsActive);

        await _unitOfWork.VendorOrderReceiveDetailBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderReceiveDetailBatchNotInserted);
    }
}
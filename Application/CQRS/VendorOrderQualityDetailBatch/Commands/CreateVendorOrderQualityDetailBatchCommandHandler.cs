using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityDetailBatch.Commands;

public class CreateVendorOrderQualityDetailBatchCommand : ICommand<Result<int>>
{
        public int? VendorOrderQualityDetailFk { get; set; }
        public int? ShelfFk { get; set; }
        public string? BatchNumber { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderQualityDetailBatchCommandHandler : ICommandHandler<CreateVendorOrderQualityDetailBatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderQualityDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderQualityDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderQualityDetailBatch.Create(request.VendorOrderQualityDetailFk, request.ShelfFk, request.BatchNumber, request.Quantity, request.ExpiryDate, request.ProductionDate, request.IsActive);

        await _unitOfWork.VendorOrderQualityDetailBatchRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderQualityDetailBatchNotInserted);
    }
}
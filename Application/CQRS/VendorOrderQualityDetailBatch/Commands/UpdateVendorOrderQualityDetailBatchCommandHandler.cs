using Application.Abstractions;

namespace Application.CQRS.VendorOrderQualityDetailBatch.Commands;

public class UpdateVendorOrderQualityDetailBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderQualityDetailFk { get; set; }
        public int? ShelfFk { get; set; }
        public string? BatchNumber { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderQualityDetailBatchCommandHandler : ICommandHandler<UpdateVendorOrderQualityDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderQualityDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderQualityDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderQualityDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderQualityDetailBatchNotFound);

        entity.Update(request.VendorOrderQualityDetailFk, request.ShelfFk, request.BatchNumber, request.Quantity, request.ExpiryDate, request.ProductionDate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderQualityDetailBatchNotUpdated);
    }
}
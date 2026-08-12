using Application.Abstractions;

namespace Application.CQRS.VendorOrderReceiveDetailBatch.Commands;

public class UpdateVendorOrderReceiveDetailBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorOrderReceiveDetailFk { get; set; }
        public int? ShelfFk { get; set; }
        public string? BatchNumber { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderReceiveDetailBatchCommandHandler : ICommandHandler<UpdateVendorOrderReceiveDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderReceiveDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderReceiveDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderReceiveDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderReceiveDetailBatchNotFound);

        entity.Update(request.VendorOrderReceiveDetailFk, request.ShelfFk, request.BatchNumber, request.Quantity, request.ReturnedQuantity, request.ExpiryDate, request.ProductionDate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderReceiveDetailBatchNotUpdated);
    }
}
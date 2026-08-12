using Application.Abstractions;

namespace Application.CQRS.InventroyItemRequestWithdrawDetail.Commands;

public class UpdateInventroyItemRequestWithdrawDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RequestWfk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? RequestedQuantity { get; set; }
        public decimal? PickedQuantity { get; set; }
        public decimal? DeliveredQuantity { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public decimal? ScrapedQuantity { get; set; }
        public int? RequestLineItemStatusFk { get; set; }
        public int? FromSerial { get; set; }
        public int? ToSerial { get; set; }
        public int? IntegrationId { get; set; }
        public bool? IsSync { get; set; }
        public decimal? LastPurchasePrice { get; set; }
        public decimal? AvgCost { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventroyItemRequestWithdrawDetailCommandHandler : ICommandHandler<UpdateInventroyItemRequestWithdrawDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventroyItemRequestWithdrawDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventroyItemRequestWithdrawDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventroyItemRequestWithdrawDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventroyItemRequestWithdrawDetailNotFound);

        entity.Update(request.RequestWfk, request.InventoryItemFk, request.RequestedQuantity, request.PickedQuantity, request.DeliveredQuantity, request.ReturnedQuantity, request.ScrapedQuantity, request.RequestLineItemStatusFk, request.FromSerial, request.ToSerial, request.IntegrationId, request.IsSync, request.LastPurchasePrice, request.AvgCost, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventroyItemRequestWithdrawDetailNotUpdated);
    }
}
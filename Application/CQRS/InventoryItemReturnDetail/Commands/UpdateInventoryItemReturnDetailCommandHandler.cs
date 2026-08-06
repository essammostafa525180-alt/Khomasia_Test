using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnDetail.Commands;

public class UpdateInventoryItemReturnDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryItemReturnFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public decimal? ExternalReturnedQuantity { get; set; }
        public int? RequestWdfk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemReturnDetailCommandHandler : ICommandHandler<UpdateInventoryItemReturnDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemReturnDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemReturnDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnDetailNotFound);

        entity.Update(request.InventoryItemReturnFk, request.InventoryItemFk, request.ReturnedQuantity, request.ReturnReasonFk, request.Notes, request.ExternalReturnedQuantity, request.RequestWdfk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnDetailNotUpdated);
    }
}
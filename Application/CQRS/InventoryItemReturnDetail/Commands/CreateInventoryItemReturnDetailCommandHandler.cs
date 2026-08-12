using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnDetail.Commands;

public class CreateInventoryItemReturnDetailCommand : ICommand<Result<int>>
{
        public int? InventoryItemReturnFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public decimal? ExternalReturnedQuantity { get; set; }
        public int? RequestWdfk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemReturnDetailCommandHandler : ICommandHandler<CreateInventoryItemReturnDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemReturnDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemReturnDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemReturnDetail.Create(request.InventoryItemReturnFk, request.InventoryItemFk, request.ReturnedQuantity, request.ReturnReasonFk, request.Notes, request.ExternalReturnedQuantity, request.RequestWdfk, request.IsActive);

        await _unitOfWork.InventoryItemReturnDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemReturnDetailNotInserted);
    }
}
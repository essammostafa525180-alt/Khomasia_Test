using Application.Abstractions;

namespace Application.CQRS.InventoryItemUoM.Commands;

public class CreateInventoryItemUoMCommand : ICommand<Result<int>>
{
        public long? InventoryItemFk { get; set; }
        public int? UnitOfMeasureFk { get; set; }
        public decimal? ConvertRate { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemUoMCommandHandler : ICommandHandler<CreateInventoryItemUoMCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemUoMCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemUoMCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemUoM.Create(request.InventoryItemFk, request.UnitOfMeasureFk, request.ConvertRate, request.IsActive);

        await _unitOfWork.InventoryItemUoMRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemUoMNotInserted);
    }
}
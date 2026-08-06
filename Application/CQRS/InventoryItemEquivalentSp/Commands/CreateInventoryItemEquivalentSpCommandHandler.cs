using Application.Abstractions;

namespace Application.CQRS.InventoryItemEquivalentSp.Commands;

public class CreateInventoryItemEquivalentSpCommand : ICommand<Result<int>>
{
        public long? InventoryItemFk { get; set; }
        public int? EquivalentItemFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemEquivalentSpCommandHandler : ICommandHandler<CreateInventoryItemEquivalentSpCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemEquivalentSpCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemEquivalentSpCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemEquivalentSp.Create(request.InventoryItemFk, request.EquivalentItemFk, request.IsActive);

        await _unitOfWork.InventoryItemEquivalentSpRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemEquivalentSpNotInserted);
    }
}
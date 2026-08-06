using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocation.Commands;

public class CreateInventoryItemLocationCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemLocationCommandHandler : ICommandHandler<CreateInventoryItemLocationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemLocation.Create(request.IsActive);

        await _unitOfWork.InventoryItemLocationRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemLocationNotInserted);
    }
}
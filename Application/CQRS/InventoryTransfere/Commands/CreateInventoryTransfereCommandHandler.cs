using Application.Abstractions;

namespace Application.CQRS.InventoryTransfere.Commands;

public class CreateInventoryTransfereCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateInventoryTransfereCommandHandler : ICommandHandler<CreateInventoryTransfereCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryTransfereCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryTransfereCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryTransfereAggregate.InventoryTransfere.Create(request.IsActive);

        await _unitOfWork.InventoryTransfereRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryTransfereNotInserted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryItemTransactionType.Commands;

public class CreateInventoryItemTransactionTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemTransactionTypeCommandHandler : ICommandHandler<CreateInventoryItemTransactionTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemTransactionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.InventoryItemTransactionType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.InventoryItemTransactionTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemTransactionTypeNotInserted);
    }
}
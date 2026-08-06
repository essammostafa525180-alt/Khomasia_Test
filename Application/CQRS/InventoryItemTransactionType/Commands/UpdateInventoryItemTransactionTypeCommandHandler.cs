using Application.Abstractions;

namespace Application.CQRS.InventoryItemTransactionType.Commands;

public class UpdateInventoryItemTransactionTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemTransactionTypeCommandHandler : ICommandHandler<UpdateInventoryItemTransactionTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemTransactionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemTransactionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemTransactionTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemTransactionTypeNotUpdated);
    }
}
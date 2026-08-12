using Application.Abstractions;

namespace Application.CQRS.InventoryItemTrasnsactionType.Commands;

public class UpdateInventoryItemTrasnsactionTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemTrasnsactionTypeCommandHandler : ICommandHandler<UpdateInventoryItemTrasnsactionTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemTrasnsactionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemTrasnsactionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemTrasnsactionTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemTrasnsactionTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemTrasnsactionTypeNotUpdated);
    }
}
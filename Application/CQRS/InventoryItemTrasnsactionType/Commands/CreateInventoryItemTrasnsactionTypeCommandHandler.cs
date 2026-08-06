using Application.Abstractions;

namespace Application.CQRS.InventoryItemTrasnsactionType.Commands;

public class CreateInventoryItemTrasnsactionTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemTrasnsactionTypeCommandHandler : ICommandHandler<CreateInventoryItemTrasnsactionTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemTrasnsactionTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemTrasnsactionTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.InventoryItemTrasnsactionType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.InventoryItemTrasnsactionTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemTrasnsactionTypeNotInserted);
    }
}
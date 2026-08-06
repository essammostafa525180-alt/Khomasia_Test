using Application.Abstractions;

namespace Application.CQRS.InventoryItemStatus.Commands;

public class CreateInventoryItemStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemStatusCommandHandler : ICommandHandler<CreateInventoryItemStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.InventoryItemStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.InventoryItemStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemStatusNotInserted);
    }
}
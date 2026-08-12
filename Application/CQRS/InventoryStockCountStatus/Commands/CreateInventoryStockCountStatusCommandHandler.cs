using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountStatus.Commands;

public class CreateInventoryStockCountStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryStockCountStatusCommandHandler : ICommandHandler<CreateInventoryStockCountStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryStockCountStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryStockCountStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.InventoryStockCountStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.InventoryStockCountStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryStockCountStatusNotInserted);
    }
}
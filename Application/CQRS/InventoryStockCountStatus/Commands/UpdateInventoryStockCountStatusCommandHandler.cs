using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountStatus.Commands;

public class UpdateInventoryStockCountStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryStockCountStatusCommandHandler : ICommandHandler<UpdateInventoryStockCountStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryStockCountStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryStockCountStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountStatusNotUpdated);
    }
}
using Application.Abstractions;

namespace Application.CQRS.InventoryTransfere.Commands;

public class UpdateInventoryTransfereCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryTransfereCommandHandler : ICommandHandler<UpdateInventoryTransfereCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryTransfereCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryTransfereCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereNotUpdated);
    }
}
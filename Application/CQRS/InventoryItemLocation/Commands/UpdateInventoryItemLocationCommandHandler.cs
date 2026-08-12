using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocation.Commands;

public class UpdateInventoryItemLocationCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemLocationCommandHandler : ICommandHandler<UpdateInventoryItemLocationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemLocationNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemLocationNotUpdated);
    }
}
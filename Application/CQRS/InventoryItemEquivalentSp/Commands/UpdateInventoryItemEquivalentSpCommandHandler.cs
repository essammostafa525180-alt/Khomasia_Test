using Application.Abstractions;

namespace Application.CQRS.InventoryItemEquivalentSp.Commands;

public class UpdateInventoryItemEquivalentSpCommand : ICommand<Result>
{
        public int Id { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? EquivalentItemFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemEquivalentSpCommandHandler : ICommandHandler<UpdateInventoryItemEquivalentSpCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemEquivalentSpCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemEquivalentSpCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemEquivalentSpRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemEquivalentSpNotFound);

        entity.Update(request.InventoryItemFk, request.EquivalentItemFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemEquivalentSpNotUpdated);
    }
}
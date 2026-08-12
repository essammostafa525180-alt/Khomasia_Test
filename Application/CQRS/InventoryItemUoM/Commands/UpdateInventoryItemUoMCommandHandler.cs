using Application.Abstractions;

namespace Application.CQRS.InventoryItemUoM.Commands;

public class UpdateInventoryItemUoMCommand : ICommand<Result>
{
        public int Id { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? UnitOfMeasureFk { get; set; }
        public decimal? ConvertRate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemUoMCommandHandler : ICommandHandler<UpdateInventoryItemUoMCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemUoMCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemUoMCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemUoMRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemUoMNotFound);

        entity.Update(request.InventoryItemFk, request.UnitOfMeasureFk, request.ConvertRate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemUoMNotUpdated);
    }
}
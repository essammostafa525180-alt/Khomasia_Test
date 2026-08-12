using Application.Abstractions;

namespace Application.CQRS.InventoryItemStatus.Commands;

public class UpdateInventoryItemStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemStatusCommandHandler : ICommandHandler<UpdateInventoryItemStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemStatusNotUpdated);
    }
}
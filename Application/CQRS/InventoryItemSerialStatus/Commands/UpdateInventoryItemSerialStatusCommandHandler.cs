using Application.Abstractions;

namespace Application.CQRS.InventoryItemSerialStatus.Commands;

public class UpdateInventoryItemSerialStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemSerialStatusCommandHandler : ICommandHandler<UpdateInventoryItemSerialStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemSerialStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemSerialStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemSerialStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemSerialStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemSerialStatusNotUpdated);
    }
}
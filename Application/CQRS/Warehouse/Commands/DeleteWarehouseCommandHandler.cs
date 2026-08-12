using Application.Abstractions;

namespace Application.CQRS.Warehouse.Commands;

public class DeleteWarehouseCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteWarehouseCommandHandler : ICommandHandler<DeleteWarehouseCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWarehouseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarehouseRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WarehouseNotFound);

        _unitOfWork.WarehouseRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WarehouseNotDeleted);
    }
}

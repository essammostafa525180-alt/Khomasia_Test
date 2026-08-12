using Application.Abstractions;

namespace Application.CQRS.WarehouseType.Commands;

public class DeleteWarehouseTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteWarehouseTypeCommandHandler : ICommandHandler<DeleteWarehouseTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWarehouseTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteWarehouseTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarehouseTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WarehouseTypeNotFound);

        _unitOfWork.WarehouseTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WarehouseTypeNotDeleted);
    }
}

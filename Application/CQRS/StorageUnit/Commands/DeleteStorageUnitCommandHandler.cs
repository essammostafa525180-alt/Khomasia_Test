using Application.Abstractions;

namespace Application.CQRS.StorageUnit.Commands;

public class DeleteStorageUnitCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteStorageUnitCommandHandler : ICommandHandler<DeleteStorageUnitCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStorageUnitCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStorageUnitCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StorageUnitRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StorageUnitNotFound);

        _unitOfWork.StorageUnitRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StorageUnitNotDeleted);
    }
}

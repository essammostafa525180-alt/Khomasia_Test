using Application.Abstractions;

namespace Application.CQRS.StoreKeeper.Commands;

public class DeleteStoreKeeperCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteStoreKeeperCommandHandler : ICommandHandler<DeleteStoreKeeperCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStoreKeeperCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStoreKeeperCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreKeeperRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StoreKeeperNotFound);

        _unitOfWork.StoreKeeperRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StoreKeeperNotDeleted);
    }
}
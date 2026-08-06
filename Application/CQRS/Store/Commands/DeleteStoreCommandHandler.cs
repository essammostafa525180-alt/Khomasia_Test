using Application.Abstractions;

namespace Application.CQRS.Store.Commands;

public class DeleteStoreCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteStoreCommandHandler : ICommandHandler<DeleteStoreCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStoreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StoreNotFound);

        _unitOfWork.StoreRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StoreNotDeleted);
    }
}
using Application.Abstractions;

namespace Application.CQRS.Store.Commands;

public class UpdateStoreCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateStoreCommandHandler : ICommandHandler<UpdateStoreCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStoreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StoreNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StoreNotUpdated);
    }
}
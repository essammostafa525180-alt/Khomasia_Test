using Application.Abstractions;

namespace Application.CQRS.StoreKeeper.Commands;

public class UpdateStoreKeeperCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? StoreFk { get; set; }
        public int? StoreKeeperFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateStoreKeeperCommandHandler : ICommandHandler<UpdateStoreKeeperCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStoreKeeperCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStoreKeeperCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreKeeperRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StoreKeeperNotFound);

        entity.Update(request.StoreFk, request.StoreKeeperFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StoreKeeperNotUpdated);
    }
}
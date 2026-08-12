using Application.Abstractions;

namespace Application.CQRS.StoreKeeper.Commands;

public class CreateStoreKeeperCommand : ICommand<Result<int>>
{
        public int? StoreFk { get; set; }
        public int? StoreKeeperFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateStoreKeeperCommandHandler : ICommandHandler<CreateStoreKeeperCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStoreKeeperCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateStoreKeeperCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.StoreKeeper.Create(request.StoreFk, request.StoreKeeperFk, request.IsActive);

        await _unitOfWork.StoreKeeperRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.StoreKeeperNotInserted);
    }
}
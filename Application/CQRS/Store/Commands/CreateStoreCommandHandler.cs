using Application.Abstractions;

namespace Application.CQRS.Store.Commands;

public class CreateStoreCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStoreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.StoreAggregate.Store.Create(request.IsActive);

        await _unitOfWork.StoreRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.StoreNotInserted);
    }
}
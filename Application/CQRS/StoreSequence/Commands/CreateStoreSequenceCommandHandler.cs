using Application.Abstractions;

namespace Application.CQRS.StoreSequence.Commands;

public class CreateStoreSequenceCommand : ICommand<Result<int>>
{
        public string TableName { get; set; }
        public int? SequenceValue { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateStoreSequenceCommandHandler : ICommandHandler<CreateStoreSequenceCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStoreSequenceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateStoreSequenceCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.StoreSequence.Create(request.TableName, request.SequenceValue, request.IsActive);

        await _unitOfWork.StoreSequenceRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.StoreSequenceNotInserted);
    }
}
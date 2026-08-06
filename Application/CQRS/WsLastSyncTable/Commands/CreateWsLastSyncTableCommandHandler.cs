using Application.Abstractions;

namespace Application.CQRS.WsLastSyncTable.Commands;

public class CreateWsLastSyncTableCommand : ICommand<Result<int>>
{
        public string? Key { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateWsLastSyncTableCommandHandler : ICommandHandler<CreateWsLastSyncTableCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateWsLastSyncTableCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateWsLastSyncTableCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.WsLastSyncTable.Create(request.Key, request.Value, request.IsActive);

        await _unitOfWork.WsLastSyncTableRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.WsLastSyncTableNotInserted);
    }
}
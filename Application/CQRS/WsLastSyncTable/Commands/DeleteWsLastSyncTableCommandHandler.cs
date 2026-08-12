using Application.Abstractions;

namespace Application.CQRS.WsLastSyncTable.Commands;

public class DeleteWsLastSyncTableCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteWsLastSyncTableCommandHandler : ICommandHandler<DeleteWsLastSyncTableCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWsLastSyncTableCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteWsLastSyncTableCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WsLastSyncTableRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WsLastSyncTableNotFound);

        _unitOfWork.WsLastSyncTableRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WsLastSyncTableNotDeleted);
    }
}
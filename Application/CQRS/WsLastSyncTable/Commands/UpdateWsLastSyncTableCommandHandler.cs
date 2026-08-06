using Application.Abstractions;

namespace Application.CQRS.WsLastSyncTable.Commands;

public class UpdateWsLastSyncTableCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateWsLastSyncTableCommandHandler : ICommandHandler<UpdateWsLastSyncTableCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWsLastSyncTableCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateWsLastSyncTableCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WsLastSyncTableRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WsLastSyncTableNotFound);

        entity.Update(request.Key, request.Value, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WsLastSyncTableNotUpdated);
    }
}
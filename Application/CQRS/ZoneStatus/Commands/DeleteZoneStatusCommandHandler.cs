using Application.Abstractions;

namespace Application.CQRS.ZoneStatus.Commands;

public class DeleteZoneStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteZoneStatusCommandHandler : ICommandHandler<DeleteZoneStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteZoneStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteZoneStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ZoneStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ZoneStatusNotFound);

        _unitOfWork.ZoneStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ZoneStatusNotDeleted);
    }
}
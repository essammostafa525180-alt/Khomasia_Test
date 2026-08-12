using Application.Abstractions;

namespace Application.CQRS.Zone.Commands;

public class DeleteZoneCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteZoneCommandHandler : ICommandHandler<DeleteZoneCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteZoneCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ZoneRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ZoneNotFound);

        _unitOfWork.ZoneRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ZoneNotDeleted);
    }
}
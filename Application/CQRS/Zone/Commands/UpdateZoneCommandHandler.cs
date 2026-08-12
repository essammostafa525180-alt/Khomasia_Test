using Application.Abstractions;

namespace Application.CQRS.Zone.Commands;

public class UpdateZoneCommand : ICommand<Result>
{
        public int Id { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateZoneCommandHandler : ICommandHandler<UpdateZoneCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateZoneCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ZoneRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ZoneNotFound);

        entity.Update(request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ZoneNotUpdated);
    }
}
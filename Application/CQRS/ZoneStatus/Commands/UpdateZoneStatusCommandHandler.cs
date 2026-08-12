using Application.Abstractions;

namespace Application.CQRS.ZoneStatus.Commands;

public class UpdateZoneStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateZoneStatusCommandHandler : ICommandHandler<UpdateZoneStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateZoneStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateZoneStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ZoneStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ZoneStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ZoneStatusNotUpdated);
    }
}
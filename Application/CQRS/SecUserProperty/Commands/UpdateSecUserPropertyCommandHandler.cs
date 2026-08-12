using Application.Abstractions;

namespace Application.CQRS.SecUserProperty.Commands;

public class UpdateSecUserPropertyCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PropertyId { get; set; }
        public int? Mode { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecUserPropertyCommandHandler : ICommandHandler<UpdateSecUserPropertyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecUserPropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecUserPropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserPropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserPropertyNotFound);

        entity.Update(request.UserId, request.PropertyId, request.Mode, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserPropertyNotUpdated);
    }
}
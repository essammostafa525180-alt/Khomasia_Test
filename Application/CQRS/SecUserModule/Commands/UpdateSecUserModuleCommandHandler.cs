using Application.Abstractions;

namespace Application.CQRS.SecUserModule.Commands;

public class UpdateSecUserModuleCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SecModuleId { get; set; }
        public bool? IsAllowed { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecUserModuleCommandHandler : ICommandHandler<UpdateSecUserModuleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecUserModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecUserModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserModuleNotFound);

        entity.Update(request.UserId, request.SecModuleId, request.IsAllowed, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserModuleNotUpdated);
    }
}
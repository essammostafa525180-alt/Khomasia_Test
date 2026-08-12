using Application.Abstractions;

namespace Application.CQRS.SecUserViewAction.Commands;

public class UpdateSecUserViewActionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ViewActionId { get; set; }
        public bool? IsAllow { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecUserViewActionCommandHandler : ICommandHandler<UpdateSecUserViewActionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecUserViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecUserViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserViewActionNotFound);

        entity.Update(request.UserId, request.ViewActionId, request.IsAllow, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserViewActionNotUpdated);
    }
}